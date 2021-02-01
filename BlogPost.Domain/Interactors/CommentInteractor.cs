using BlogPost.Domain.Models;
using BlogPost.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Interactors
{
    public class CommentInteractor : ICommentInteractor
    {
        protected readonly IDataAccess _dataAccess;

        public CommentInteractor(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess ??
               throw new ArgumentNullException($"{nameof(dataAccess)}");
        }

        public async Task<Comment> AddAsync(Comment entity)
        {
            var comment = await _dataAccess.CommentDao.AddAsync(entity);

            return comment;
        }
    }
}
