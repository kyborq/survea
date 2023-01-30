using Core.Entities;
using Web.Api.Dtos;

namespace Web.Api.Mappings
{
    public static class DetailedTestInfoMappings
    {
        public static DetailedTestInfoDto MapToDto( this DetailedTestInfo detailedTestInfo )
        {
            return new DetailedTestInfoDto
            {
                AttemptCount = detailedTestInfo.AttemptCount,
                AverageTestCompletionTime = detailedTestInfo.AverageTestCompletionTime
            };
        }
    }
}
