using Core.Entities;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        public Test GetById( int id );
    }
}
