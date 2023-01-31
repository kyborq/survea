using Core.Entities;
using System.Collections.Generic;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IAttemptRepository : IRepository<PassedTest>
    {
        public PassedTest GetById( int id );
        public List<PassedTest> GetByUserId( int userId );
        public List<PassedTest> GetByTestId( int testId );
    }
}
