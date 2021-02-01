using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPost.Domain.Contracts
{
    public interface IDataAccess
    {
        ICommentDao CommentDao { get; }

        IPostDao PostDao { get; }
    }
}
