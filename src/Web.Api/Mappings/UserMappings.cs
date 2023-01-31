using Core.Entities;
using System.Collections.Generic;
using Utils.Extensions;
using Web.Api.Dtos;

namespace Web.Api.Mappings
{
    public static class UserMappings
    {
        public static UserDto MapToDto( this User user )
        {
            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                AccountMode = user.AccountMode
            };
        }

        public static UserFullInfoDto MapToFullInfoDto( this User user, bool includeDetailedInfo = true, 
            bool includeTags = true, bool includeTestIds = true, bool includeAttemptIds = true )
        {
            UserFullInfoDto dto = new UserFullInfoDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                AccountMode = user.AccountMode,
                DetailedUserInfo = null,
                Tags = null,
                TestIds = null,
                AttemptIds = null
            };

            if ( includeDetailedInfo )
            {
                dto.DetailedUserInfo = user.DetailedUserInfo.MapToDto();
            }

            if ( includeTags )
            {
                dto.Tags = new List<string>();
                foreach ( var tag in user.Tags )
                {
                    dto.Tags.Add( tag.TagValue );
                }
            }

            if ( includeTestIds )
            {
                dto.TestIds = new List<int>();
                foreach ( var test in user.Tests )
                {
                    dto.TestIds.Add( test.TestId );
                }
            }

            if ( includeAttemptIds )
            {
                dto.AttemptIds = new List<int>();
                foreach ( var attempt in user.PassedTests )
                {
                    dto.AttemptIds.Add( attempt.TestPassingId );
                }
            }

            return dto;
        }

        public static User MapToUser( this RegisterUserDto dto, DetailedUserInfo detailedUserInfo )
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                AccountMode = dto.AccountMode,
                DetailedUserInfo = detailedUserInfo,
                PassedTests = new List<PassedTest>(),
                PasswordHash = dto.Password.GetHash(),
                ReferalCode = null,
                Tags = new List<Tag>(),
                Tests = new List<Test>()
            };
        }
    }
}
