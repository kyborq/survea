using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStorage.MsSql.UnitOfWorkImplementation
{
    public class MsSqlUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public MsSqlUnitOfWork( IDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
