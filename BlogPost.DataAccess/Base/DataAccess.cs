using System;
using System.Collections.Generic;
using System.Text;
using BlogPost.Domain.Contracts;

namespace BlogPost.DataAccess.Base
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(
            IPostDao postDao,
            ICommentDao commentDao)
        {
            PostDao = postDao ??
                throw new ArgumentNullException($"{nameof(postDao)}");

            CommentDao = commentDao ??
                throw new ArgumentNullException($"{nameof(commentDao)}");
        }

        public IPostDao PostDao { get; }

        public ICommentDao CommentDao { get; }
    }
}
