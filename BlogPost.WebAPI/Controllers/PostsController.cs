using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PostsController : BaseController
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IPostInteractor _postInteractor;

        public PostsController(
            ILogger<PostsController> logger,
            ModelMappingService mapper,
            IPostInteractor postInteractor) : base(mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _postInteractor = postInteractor ??
               throw new ArgumentNullException($"{nameof(postInteractor)}");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAll()
        {
            var posts = await _postInteractor.GetAllAsync();

            if (posts == null)
            {
                _logger.LogInformation("The Posts not found in GetAll() method");

                return NotFound(new { Message = $"The Posts not found." });
            }

            var postDTOs = _mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);

            return Ok(postDTOs.ToList());
        }

        // GET api/posts/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> Get([FromRoute] Guid id)
        {
            var post = await _postInteractor.GetByIdAsync(id);

            if (post == null)
            {
                _logger.LogError($"The Post Id {id} not found in Get([FromRoute] Guid id) method");

                return NotFound(new { Message = $"The Post Id {id} not found." });
            }

            var postDTO = _mapper.Map<Post, PostDTO>(post);

            return Ok(postDTO);
        }

        [HttpPost]
        public async Task<ActionResult<PostDTO>> Post([FromBody] PostRequest postRequest)
        {
            if (postRequest.PostDate.Year < 1900)
            {
                postRequest.PostDate = DateTime.UtcNow;
            }

            Post mappedPost = _mapper.Map<PostRequest, Post>(postRequest);
            mappedPost.Id = Guid.NewGuid();
            
            var post = await _postInteractor.AddAsync(mappedPost);
            PostDTO postDTO = _mapper.Map<Post, PostDTO>(post);

            _logger.LogInformation($"The Post Id {postDTO.Id} has been successfully created.");

            return CreatedAtAction(nameof(Get), new { id = postDTO.Id }, postDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _postInteractor.RemoveAsync(id);

            if (result)
            {
                _logger.LogInformation($"The Post {id} has been successfully deleted.");

                return NoContent();
            }
            else
            {
                var errorMessage = $"The Post {id} can not be deleted because it is not an empty.";

                _logger.LogError(errorMessage);

                return BadRequest(new { Message = errorMessage });
            }
        }

    }
}
