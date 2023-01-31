using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestStorage.Abstractions;
using Web.Api.Dtos;
using Web.Api.Mappings;

namespace Web.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ITestStorage _testStorage;

        public TestController( 
            ITestRepository testRepository, 
            IUserRepository userRepository, 
            ITagRepository tagRepository, 
            ITestStorage testStorage )
        {
            _testRepository = testRepository;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
            _testStorage = testStorage;
        }

        [Authorize]
        [HttpGet( "{id}" )]
        public TestDto GetTest( [FromRoute] int id )
        {
            Test test = _testRepository.GetById( id );
            _testStorage.LoadQuestions( test );
            return test.MapToTestWithQuestions();
        }

        [Authorize]
        [HttpGet( "{id}/full" )]
        public TestFullInfoDto GetTestFullInfo( [FromRoute] int id )
        {
            Test test = _testRepository.GetWithFullInfoById( id );
            _testStorage.LoadQuestions( test );
            return test.MapToTestFullInfoWithQuestions();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateTest( [FromBody] CreateTestDto dto )
        {
            Test test = new Test
            {
                Name = dto.Name,
                AgeRestriction = dto.AgeRestriction,
                Description = dto.Description,
                QuestionCount = dto.Questions.Count,
                Questions = dto.Questions
            };
            string idString = HttpContext.User.Claims.Where( c => c.Type == ClaimTypes.Name ).FirstOrDefault()?.Value;
            if ( idString == null )
            {
                return Unauthorized();
            }
            int id = int.Parse( idString );
            User user = _userRepository.GetWithFullInfoById( id, includeTags: false, includeTests: false, includAttempts: false );
            if ( !user.IsAllowedToCreateTests() )
            {
                return Forbid();
            }
            test.Owner = user;
            List<Tag> existingTags = _tagRepository.GetAll().ToList();
            List<Tag> tagsToSet = existingTags.Where( t => dto.Tags.Contains( t.TagValue ) ).ToList();
            test.Tags = tagsToSet;
            test.DetailedTestInfo = new DetailedTestInfo
            {
                AttemptCount = 0,
                AverageTestCompletionTime = 0
            };
            test.CreationDate = DateTime.UtcNow;
            _testRepository.Add( test );
            user.DetailedUserInfo.CreatedTestCount++;
            _testRepository.SaveChanges();
            _testStorage.Save( test );
            return Ok();
        }
    }
}
