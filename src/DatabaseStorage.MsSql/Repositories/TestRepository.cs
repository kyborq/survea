using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using System.Linq;

namespace DatabaseStorage.MsSql.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository( ApplicationContext context )
            : base( context )
        {
        }

        public Test GetById( int id )
        {
            return Entities.Where( t => t.TestId == id ).FirstOrDefault();
        }
    }
}
