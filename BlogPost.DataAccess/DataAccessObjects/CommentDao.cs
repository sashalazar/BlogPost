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
    public class CommentDao : ICommentDao
    {
        protected readonly DbModelMapper _mapper;

        public CommentDao(DbModelMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException($"{nameof(mapper)}");
        }

        public async Task<Comment> AddAsync(Comment entity)
        {
            using (var context = new BlogPostDbContext(new DbContextOptions<BlogPostDbContext>()))
            {
                var postExists = await context.Set<PostEntity>().AnyAsync(x => x.Id == entity.PostId);

                if (!postExists)
                {
                    throw new InvalidOperationException($"Comment can not be added. The Post {entity.PostId} can not be found.");
                }

                var commentEntity = _mapper.Map<Comment, CommentEntity>(entity);

                var addedComment = await context.Set<CommentEntity>().AddAsync(commentEntity);

                await context.SaveChangesAsync();

                return _mapper.Map<CommentEntity, Comment>(addedComment.Entity);
            }
        }
    }
}
