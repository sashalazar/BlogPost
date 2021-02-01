using BlogPost.DataAccess.DBContext;
using BlogPost.DataAccess.Base;
using BlogPost.DataAccess.DataAccessObjects;
using BlogPost.Domain.Interactors;
using BlogPost.Domain.Contracts;
using BlogPost.WebAPI.Middleware.Extensions;
using BlogPost.WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions();

            services.AddLogging(builder => builder
                .ClearProviders()
                .AddConsole()
            );

            services.AddControllers();

            services.AddDbContext<BlogPostDbContext>();

            services.AddSingleton<ModelMappingService>();
            services.AddSingleton<DbModelMapper>();

            services.AddScoped<IPostInteractor, PostInteractor>();
            services.AddScoped<ICommentInteractor, CommentInteractor>();

            services.AddScoped<IPostDao, PostDao>();
            services.AddScoped<ICommentDao, CommentDao>();

            services.AddScoped<IDataAccess, BlogPost.DataAccess.Base.DataAccess>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorWrapping();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
