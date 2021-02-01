using BlogPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Contracts
{
    public interface IPostDao
    {
        Task<IEnumerable<Post>> GetAllAsync();

        Task<Post> GetByIdAsync(Guid id);

        Task<Post> AddAsync(Post entity);

        Task<bool> RemoveAsync(Guid id);
    }
}
