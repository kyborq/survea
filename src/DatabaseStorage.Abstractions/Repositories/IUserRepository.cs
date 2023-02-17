using Core.Entities;
using System.Collections.Generic;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public List<User> GetAll();
        public User GetById( int userId );
        public User GetWithFullInfoById( int userId, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeTests = true, bool includAttempts = true );
        public User GetByEmail( string email );
    }
}
