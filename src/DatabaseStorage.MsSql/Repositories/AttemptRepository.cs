using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseStorage.MsSql.Repositories
{
    // TODO: async/await
    public class AttemptRepository : Repository<PassedTest>, IAttemptRepository
    {
        public AttemptRepository( ApplicationContext context )
            : base( context )
        {
        }

        public PassedTest GetById( int id )
        {
            return Entities.Include( a => a.Answers ).Where( a => a.TestPassingId == id ).FirstOrDefault();
        }

        public List<PassedTest> GetByTestId( int testId )
        {
            return Entities.Include( a => a.Answers ).Where( a => a.TestId == testId ).ToList();
        }

        public List<PassedTest> GetByUserId( int userId )
        {
            return Entities.Include( a => a.Answers ).Where( a => a.UserId == userId ).ToList();
        }
    }
}
