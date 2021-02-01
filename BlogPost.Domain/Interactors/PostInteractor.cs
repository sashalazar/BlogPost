using BlogPost.Domain.Models;
using BlogPost.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPost.Domain.Interactors
{
    public class PostInteractor : IPostInteractor
    {
        protected readonly IDataAccess _dataAccess;

        public PostInteractor(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess ??
               throw new ArgumentNullException($"{nameof(dataAccess)}");
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var posts = await _dataAccess.PostDao.GetAllAsync();

            return posts;
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            var post = await _dataAccess.PostDao.GetByIdAsync(id);

            return post;
        }

        public async Task<Post> AddAsync(Post entity)
        {
            var post = await _dataAccess.PostDao.AddAsync(entity);

            return post;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var result = await _dataAccess.PostDao.RemoveAsync(id);

            return result;
        }
    }
}
