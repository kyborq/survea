using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseStorage.MsSql.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository( ApplicationContext context )
            : base( context )
        {
        }

        public List<Tag> GetAll()
        {
            return Entities.ToList();
        }
    }
}
