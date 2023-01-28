using Core.Entities;
using System;
using System.Collections.Generic;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetById( int userId );
        public User GetWithFullInfoById( int userId, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeTests = true );
        public User GetByEmail( string email );
        [Obsolete]
        public List<User> GetAll();
    }
}
