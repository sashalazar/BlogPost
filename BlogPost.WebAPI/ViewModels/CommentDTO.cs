using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.WebAPI.ViewModels
{
    public class CommentDTO
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public string Text { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
