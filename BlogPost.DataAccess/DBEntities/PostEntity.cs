using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogPost.DataAccess.DBEntities
{
    public class PostEntity 
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    }
}
