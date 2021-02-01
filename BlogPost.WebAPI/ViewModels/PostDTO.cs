using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.WebAPI.ViewModels
{
    public class PostDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
    }
}
