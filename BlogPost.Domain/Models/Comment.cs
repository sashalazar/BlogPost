using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPost.Domain.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }

        public string Text { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
