﻿using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatabaseStorage.MsSql.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository( ApplicationContext context )
            : base( context )
        {
        }

        public User GetById( int userId )
        {
            return Entities.Where( u => u.UserId == userId ).FirstOrDefault();
        }

        public User GetWithFullInfoById( int userId, bool includeDetailedInfo = true,
            bool includeTags = true, bool includeTests = true )
        {
            var query = Entities.AsQueryable();
            if ( includeDetailedInfo )
            {
                query = query.Include( u => u.DetailedUserInfo );
            }
            if ( includeTags )
            {
                query = query.Include( u => u.Tags );
            }
            if ( includeTests )
            {
                query = query.Include( u => u.Tests );
            }
            return query.Where( u => u.UserId == userId ).FirstOrDefault();
        }
    }
}
