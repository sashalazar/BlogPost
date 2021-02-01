using AutoMapper;
using BlogPost.Domain.Models;
using BlogPost.WebAPI.ViewModels;
using BlogPost.WebAPI.ViewModels.RequestModels;


namespace BlogPost.WebAPI.Services
{
    public class ModelMappingService
    {
        private IMapper _mapper;

        public ModelMappingService()
        {
            _mapper = CreateMapper();
        }

        public R Map<T, R>(T entity)
        {
            if (entity == null)
            {
                return default;
            }

            return _mapper.Map<R>(entity);
        }

        private IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostRequest, Post>().ReverseMap();
                cfg.CreateMap<CommentRequest, Comment>().ReverseMap();

                cfg.CreateMap<Post, PostDTO>().ReverseMap();
                cfg.CreateMap<Comment, CommentDTO>().ReverseMap();
            });

            return configuration.CreateMapper();
        }
    }
}
