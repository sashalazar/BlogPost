using AutoMapper;
using BlogPost.DataAccess.DBEntities;
using BlogPost.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPost.DataAccess.Base
{
    public class DbModelMapper
    {
        private IMapper _mapper;

        public DbModelMapper()
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
                cfg.CreateMap<Post, PostEntity>().ReverseMap();
                cfg.CreateMap<Comment, CommentEntity>().ReverseMap();
            });

            return configuration.CreateMapper();
        }
    }
}
