using BlogPost.DataAccess.Base;
using BlogPost.DataAccess.DBContext;
using BlogPost.DataAccess.DBEntities;
using BlogPost.Domain.Contracts;
using BlogPost.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.DataAccess.DataAccessObjects
{
    public class PostDao : IPostDao
    {
        protected readonly DbModelMapper _mapper;

        public PostDao(DbModelMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException($"{nameof(mapper)}");
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            using (var context = new BlogPostDbContext(new DbContextOptions<BlogPostDbContext>()))
            {
                var posts = await context.Posts
                    .OrderBy(pst => pst.PostDate)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<PostEntity>, IEnumerable<Post>>(posts);
            }
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            using (var context = new BlogPostDbContext(new DbContextOptions<BlogPostDbContext>()))
            {
                var postEntity = await context.Posts
                    .Include(pst => pst.Comments)
                    .SingleOrDefaultAsync(pst => pst.Id == id);

                return _mapper.Map<PostEntity, Post>(postEntity);
            }
        }

        public async Task<Post> AddAsync(Post post)
        {
            using (var context = new BlogPostDbContext(new DbContextOptions<BlogPostDbContext>()))
            {
                var postEntity = _mapper.Map<Post, PostEntity>(post);

                var addedPost = await context.Set<PostEntity>().AddAsync(postEntity);

                await context.SaveChangesAsync();

                return _mapper.Map<PostEntity, Post>(addedPost.Entity);
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            using (var context = new BlogPostDbContext(new DbContextOptions<BlogPostDbContext>()))
            {
                var postEntity = await context.Posts
                    .Include(pst => pst.Comments)
                    .SingleOrDefaultAsync(pst => pst.Id == id);

                if (postEntity == null)
                {
                    throw new InvalidOperationException($"The Post Id {id} can not be found.");
                }

                if (postEntity.Comments.Count != 0)
                {
                    return false;
                }

                context.Posts.Remove(postEntity);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
