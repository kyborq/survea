using Core.Entities;
using System.Collections.Generic;

namespace DatabaseStorage.Abstractions.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        public List<Tag> GetAll();
    }
}
