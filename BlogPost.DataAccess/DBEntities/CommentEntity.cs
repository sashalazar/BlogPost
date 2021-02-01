using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogPost.DataAccess.DBEntities
{
    public class CommentEntity
    {
        public Guid Id { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public virtual PostEntity Post { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }
    }
}
