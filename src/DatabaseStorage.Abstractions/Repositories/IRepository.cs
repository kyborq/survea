using System.Linq;

// TODO: переименовать в стораге???
namespace DatabaseStorage.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IAddRepository<TEntity>, IRemoveRepository<TEntity>
        where TEntity : class
    {
        public void SaveChanges();
    }
}
