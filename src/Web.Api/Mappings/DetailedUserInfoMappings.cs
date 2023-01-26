using Core.Entities;
using Web.Api.Dtos;

namespace Web.Api.Mappings
{
    public static class DetailedUserInfoMappings
    {
        public static DetailedUserInfoDto MapToDto( this DetailedUserInfo detailedUserInfo )
        {
            return new DetailedUserInfoDto
            {
                CreatedTestCount = detailedUserInfo.CreatedTestCount,
                PassedTestCount = detailedUserInfo.PassedTestCount,
                RegistrationDate = detailedUserInfo.RegistrationDate,
                Gender = detailedUserInfo.Gender
            };
        }
    }
}
