using BlogPost.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogPost.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ModelMappingService _mapper;

        public BaseController(ModelMappingService mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException($"{nameof(mapper)}");
        }
    }
}
