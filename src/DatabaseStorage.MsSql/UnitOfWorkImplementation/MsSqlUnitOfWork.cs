using Core.Entities;
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
        private readonly ApplicationContext _dbContext;

        public MsSqlUnitOfWork( ApplicationContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            var a = _dbContext.Set<User>().ToList();
            _dbContext.SaveChanges();
        }
    }
}
