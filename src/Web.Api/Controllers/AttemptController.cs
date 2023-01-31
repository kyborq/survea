using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Web.Api.Dtos;
using Web.Api.Mappings;

namespace Web.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class AttemptController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITestRepository _testRepository;
        private readonly IAttemptRepository _attemptRepository;

        public AttemptController( 
            IUserRepository userRepository, 
            ITestRepository testRepository,
            IAttemptRepository attemptRepository )
        {
            _userRepository = userRepository;
            _testRepository = testRepository;
            _attemptRepository = attemptRepository;
        }

        [Authorize]
        [HttpGet( "by-id/{id}" )]
        public AttemptDto GetAttemptById( [FromRoute] int id )
        {
            return _attemptRepository.GetById( id ).MapToAttemptDto();
        }

        [Authorize]
        [HttpGet( "for-current-user" )]
        public IActionResult GetAttemptByUser()
        {
            string idString = HttpContext.User.Claims.Where( c => c.Type == ClaimTypes.Name ).FirstOrDefault()?.Value;
            if ( idString == null )
            {
                return Unauthorized();
            }
            int id = int.Parse( idString );
            return Ok( _attemptRepository.GetByUserId( id ).Select( t => t.MapToAttemptDto() ).ToList() );
        }

        [Authorize]
        [HttpGet( "by-test-id/{id}" )]
        public List<AttemptDto> GetAttemptsByTestId( [FromRoute] int id )
        {
            return _attemptRepository.GetByTestId( id ).Select( t => t.MapToAttemptDto() ).ToList();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddAttempt( [FromBody] NewAttemptDto dto )
        {
            string idString = HttpContext.User.Claims.Where( c => c.Type == ClaimTypes.Name ).FirstOrDefault()?.Value;
            if ( idString == null )
            {
                return Unauthorized();
            }
            int id = int.Parse( idString );
            List<Answer> answers = new List<Answer>();
            foreach ( var answerDto in dto.Answers )
            {
                answers.Add( new Answer
                {
                    AnswerText = answerDto.AnswerText,
                    QuestionNumber = answerDto.QuestionNumber,
                    QuestionType = answerDto.QuestionType
                } );
            }
            PassedTest newPassedTest = new PassedTest
            {
                TestId = dto.TestId,
                UserId = id,
                FinishedAt = DateTime.UtcNow,
                Answers = answers
            };
            _attemptRepository.Add( newPassedTest );
            Test test = _testRepository.GetWithFullInfoById( dto.TestId, 
                includeTags: false, includeOwner: false, includePassingAttemps: false );
            test.DetailedTestInfo.AttemptCount++;
            User user = _userRepository.GetWithFullInfoById( id, includeTags: false, includeTests: false, includAttempts: false );
            user.DetailedUserInfo.PassedTestCount++;
            _attemptRepository.SaveChanges();
            return Ok();
        }
    }
}
