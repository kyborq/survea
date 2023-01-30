using Core.Entities;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        public Test GetById( int id );
        public Test GetWithFullInfoById( int testId, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeOwner = true, bool includePassingAttemps = true );
    }
}
