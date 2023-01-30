using Core.Entities;
using System.Collections.Generic;
using Web.Api.Dtos;

namespace Web.Api.Mappings
{
    public static class TestMappings
    {
        public static TestDto MapToTestInfo( this Test test )
        {
            return new TestDto
            {
                TestId = test.TestId,
                Name = test.Name,
                Description = test.Description,
                AgeRestriction = test.AgeRestriction,
                CreationDate = test.CreationDate,
                QuestionCount = test.QuestionCount
            };
        }

        public static TestDto MapToTestWithQuestions( this Test test )
        {
            return new TestDto
            {
                TestId = test.TestId,
                Name = test.Name,
                Description = test.Description,
                AgeRestriction = test.AgeRestriction,
                CreationDate = test.CreationDate,
                QuestionCount = test.QuestionCount,
                Questions = test.Questions
            };
        }

        public static TestFullInfoDto MapToTestFullInfo( this Test test, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeOwner = true, bool includePassingAttemps = true )
        {
            TestFullInfoDto dto = new TestFullInfoDto
            {
                TestId = test.TestId,
                Name = test.Name,
                Description = test.Description,
                AgeRestriction = test.AgeRestriction,
                CreationDate = test.CreationDate,
                QuestionCount = test.QuestionCount,
                AttemptIds = new List<int>(),
                DetailedTestInfo = null,
                Tags = new List<string>()
            };

            if ( includeDetailedInfo )
            {
                dto.DetailedTestInfo = test.DetailedTestInfo.MapToDto();
            }

            if ( includeTags )
            {
                dto.Tags = new List<string>();
                foreach ( var tag in test.Tags )
                {
                    dto.Tags.Add( tag.TagValue );
                }
            }

            if ( includeOwner )
            {
                dto.OwnerId = test.OwnerId;
            }

            if ( includePassingAttemps )
            {
                dto.AttemptIds = new List<int>();
                foreach ( var attempt in test.Attempts )
                {
                    dto.AttemptIds.Add( attempt.TestPassingId );
                }
            }

            return dto;
        }

        public static TestFullInfoDto MapToTestFullInfoWithQuestions( this Test test, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeOwner = true, bool includePassingAttemps = true )
        {
            TestFullInfoDto dto = new TestFullInfoDto
            {
                TestId = test.TestId,
                Name = test.Name,
                Description = test.Description,
                AgeRestriction = test.AgeRestriction,
                CreationDate = test.CreationDate,
                QuestionCount = test.QuestionCount,
                Questions = test.Questions,
                AttemptIds = new List<int>(),
                DetailedTestInfo = null,
                Tags = new List<string>()
            };

            if ( includeDetailedInfo )
            {
                dto.DetailedTestInfo = test.DetailedTestInfo.MapToDto();
            }

            if ( includeTags )
            {
                dto.Tags = new List<string>();
                foreach ( var tag in test.Tags )
                {
                    dto.Tags.Add( tag.TagValue );
                }
            }

            if ( includeOwner )
            {
                dto.OwnerId = test.OwnerId;
            }

            if ( includePassingAttemps )
            {
                dto.AttemptIds = new List<int>();
                foreach ( var attempt in test.Attempts )
                {
                    dto.AttemptIds.Add( attempt.TestPassingId );
                }
            }

            return dto;
        }
    }
}
