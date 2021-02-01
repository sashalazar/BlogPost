using BlogPost.DataAccess.Helpers;
using BlogPost.DataAccess.DBEntities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace BlogPost.DataAccess.DBContext
{
    public class BlogPostDbContext : DbContext
    {

        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> context) : base(context)
        {
            Database.EnsureCreated();
            //if (System.Diagnostics.Debugger.IsAttached == false) { System.Diagnostics.Debugger.Launch(); }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("BlogPostDbContext");

            if (string.IsNullOrEmpty(connectionString))
            {
                IConfiguration configuration = ConfigurationHelper.GetConfig();
                connectionString = configuration.GetConnectionString("BlogPostDbContext");
            }

            optionsBuilder
                .UseSqlServer(connectionString);
                //.UseLazyLoadingProxies();
        }

        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentEntity>()
            .HasOne(cmt => cmt.Post)
            .WithMany(pst => pst.Comments)
            .HasForeignKey(cmt => cmt.PostId);
        }
    }
}
