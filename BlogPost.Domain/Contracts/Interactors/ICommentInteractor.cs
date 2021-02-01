using BlogPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Contracts
{
    public interface ICommentInteractor
    {
        Task<Comment> AddAsync(Comment entity);
    }
}
