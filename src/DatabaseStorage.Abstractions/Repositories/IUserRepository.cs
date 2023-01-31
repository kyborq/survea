using Core.Entities;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetById( int userId );
        public User GetWithFullInfoById( int userId, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeTests = true, bool includAttempts = true );
        public User GetByEmail( string email );
    }
}
