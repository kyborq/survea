using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseStorage.MsSql.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository( ApplicationContext context )
            : base( context )
        {
        }

        public List<Test> GetAll()
        {
            return Entities.ToList();
        }

        public Test GetById( int id )
        {
            return Entities.Where( t => t.TestId == id ).FirstOrDefault();
        }

        public Test GetWithFullInfoById( int testId, bool includeDetailedInfo = true, 
            bool includeTags = true, bool includeOwner = true, bool includePassingAttemps = true )
        {
            var query = Entities.AsQueryable();
            if ( includeDetailedInfo )
            {
                query = query.Include( t => t.DetailedTestInfo );
            }
            if ( includeTags )
            {
                query = query.Include( t => t.Tags );
            }
            if ( includeOwner )
            {
                query = query.Include( t => t.Owner );
            }
            if ( includePassingAttemps )
            {
                query = query.Include( t => t.Attempts );
            }
            return query.Where( t => t.TestId == testId ).FirstOrDefault();
        }
    }
}
