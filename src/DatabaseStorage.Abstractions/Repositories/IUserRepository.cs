using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetById( int userId );
        public User GetWithFullInfoById( int userId, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeTests = true );
    }
}
