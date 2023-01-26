using System.Collections.Generic;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IRemoveRepository<TEntity> where TEntity : class
    {
        public void Remove( TEntity entity );
        public void Remove( IEnumerable<TEntity> entities );
    }
}
