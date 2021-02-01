using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.WebAPI.ViewModels.RequestModels
{
    public class CommentRequest
    {
        public Guid Id { get; set; }

        [Required]
        public Guid PostId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
