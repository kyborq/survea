using System.Linq;

// TODO: переименовать в стораге???
namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IAddRepository<TEntity>, IRemoveRepository<TEntity>
        where TEntity : class
    {
        // Table убрать, смотреть PrO
        //public IQueryable<T> Table { get; }
        // TODO: UnitOfWork
        // PrO
        //public void SaveChanges();
    }
}
