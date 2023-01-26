using System.Threading;
using System.Threading.Tasks;

namespace DatabaseStorage.MsSql
{
    public interface IDbContext
    {
        public int SaveChanges();
        public Task<int> SaveChangesAsync( CancellationToken cancellationToken = default );
    }
}
