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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IDetailedUserInfoRepository _detailedUserInfoRepository;
        private readonly ITagRepository _tagRepository;

        public UserController( 
            IUserRepository userRepository, 
            IDetailedUserInfoRepository detailedUserInfoRepository,
            ITagRepository tagRepository )
        {
            _userRepository = userRepository;
            _detailedUserInfoRepository = detailedUserInfoRepository;
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public List<UserDto> GetAll()
        {
            return _userRepository.GetAll().Select( u => u.MapToDto() ).ToList();
        }

        [Authorize]
        [HttpGet( "{id}" )]       
        public UserDto GetUser( [FromRoute] int id )
        {
            return _userRepository.GetById( id )?.MapToDto();
        }

        [Authorize]
        [HttpGet( "{id}/full" )]
        public UserFullInfoDto GetUserFullInfo( [FromRoute] int id )
        {
            return _userRepository.GetWithFullInfoById( id )?.MapToFullInfoDto();
        }

        [HttpPost]
        public void RegisterUser( [FromBody] RegisterUserDto dto )
        {
            var detailedInfo = new DetailedUserInfo
            {
                CreatedTestCount = 0,
                PassedTestCount = 0,
                Gender = Gender.Undefined,
                RegistrationDate = DateTime.UtcNow
            };
            _detailedUserInfoRepository.Add( detailedInfo );
            _userRepository.Add( dto.MapToUser( detailedInfo ) );
        }

        [Authorize]
        [HttpPost( "info" )]
        public IActionResult UpdateDetailedUserInfo( [FromBody] UpdateUserDetailedInfoDto dto )
        {
            string idString = HttpContext.User.Claims.Where( c => c.Type == ClaimTypes.Name ).FirstOrDefault()?.Value;
            if ( idString == null )
            {
                return Unauthorized();
            }
            int id = int.Parse( idString );
            User user = _userRepository.GetWithFullInfoById( id, includeTags: false, includeTests: false );
            user.DetailedUserInfo.Gender = dto.Gender;
            _userRepository.SaveChanges();
            return Ok();
        }

        [Authorize]
        [HttpPost( "tags" )]
        public IActionResult SetUserTags( SetTagsDto dto )
        {
            List<Tag> existingTags = _tagRepository.GetAll().ToList();
            List<Tag> tagsToSet = existingTags.Where( t => dto.Tags.Contains( t.TagValue ) ).ToList();
            string idString = HttpContext.User.Claims.Where( c => c.Type == ClaimTypes.Name ).FirstOrDefault()?.Value;
            if ( idString == null )
            {
                return Unauthorized();
            }
            int id = int.Parse( idString );
            User user = _userRepository.GetWithFullInfoById( id, includeDetailedInfo: false, includeTests: false );
            user.Tags = tagsToSet;
            _userRepository.SaveChanges();
            return Ok();
        }

        [Authorize]
        [HttpPost( "referal" )]
        public IActionResult GenerateReferalCode()
        {
            string idString = HttpContext.User.Claims.Where( c => c.Type == ClaimTypes.Name ).FirstOrDefault()?.Value;
            if ( idString == null )
            {
                return Unauthorized();
            }
            int id = int.Parse( idString );
            User user = _userRepository.GetById( id );
            if ( user.ReferalCode != null )
            {
                return Ok( user.ReferalCode.Code );
            }
            user.ReferalCode = new ReferalCode { Code = Guid.NewGuid().ToString() };
            _userRepository.SaveChanges();
            return Ok( user.ReferalCode.Code );
        }
    }
}
