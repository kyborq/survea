using DatabaseStorage.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DatabaseStorage.MsSql.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> Entities { get; }
        private readonly ApplicationContext _context;

        public Repository( ApplicationContext context )
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }

        public void Add( TEntity entity )
        {
            Entities.Add( entity );
            _context.SaveChanges();
        }

        public void Add( IEnumerable<TEntity> entities )
        {
            Entities.AddRange( entities );
            _context.SaveChanges();
        }

        public void Remove( TEntity entity )
        {
            Entities.Remove( entity );
            _context.SaveChanges();
        }

        public void Remove( IEnumerable<TEntity> entities )
        {
            Entities.RemoveRange( entities );
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
