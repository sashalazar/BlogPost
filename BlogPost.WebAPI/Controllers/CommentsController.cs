using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using BlogPost.Domain.Contracts;
using BlogPost.Domain.Models;
using BlogPost.WebAPI.Services;
using BlogPost.WebAPI.ViewModels;
using BlogPost.WebAPI.ViewModels.RequestModels;

namespace BlogPost.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : BaseController
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly ICommentInteractor _commentInteractor;

        public CommentsController(
            ILogger<CommentsController> logger,
            ModelMappingService mapper,
            ICommentInteractor commentInteractor) : base(mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _commentInteractor = commentInteractor ??
                throw new ArgumentNullException($"{nameof(commentInteractor)}");
        }

        [HttpPost]
        public async Task<ActionResult<CommentDTO>> Post([FromBody] CommentRequest commentRequest)
        {
            if (commentRequest.CommentDate.Year < 1900)
            {
                commentRequest.CommentDate = DateTime.UtcNow;
            }

            Comment mappedComment = _mapper.Map<CommentRequest, Comment>(commentRequest);
            mappedComment.Id = Guid.NewGuid();

            var comment = await _commentInteractor.AddAsync(mappedComment);
            CommentDTO commentDTO = _mapper.Map<Comment, CommentDTO>(comment);

            _logger.LogInformation($"Comment {commentDTO.Id} has been successfully created.");

            return CreatedAtRoute(new { id = commentDTO.Id }, commentDTO);
        }

    }
}
