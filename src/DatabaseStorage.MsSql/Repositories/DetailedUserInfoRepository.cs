using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;

namespace DatabaseStorage.MsSql.Repositories
{
    public class DetailedUserInfoRepository : Repository<DetailedUserInfo>, IDetailedUserInfoRepository
    {
        public DetailedUserInfoRepository( ApplicationContext context )
            : base( context )
        {
        }
    }
}
