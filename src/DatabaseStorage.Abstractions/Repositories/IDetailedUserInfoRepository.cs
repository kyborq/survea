using Core.Entities;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IDetailedUserInfoRepository : IRepository<DetailedUserInfo>
    {
        public Test GetById( int id );
    }
}
