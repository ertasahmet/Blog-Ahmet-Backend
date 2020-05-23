using BlogAhmet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.DataAccess.Concrete.EntityFramework
{
    public class BlogAhmetContext : DbContext
    {

        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<BlogAhmetContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }

            public DbContextOptionsBuilder<BlogAhmetContext> opsBuilder { get; set; }

            public DbContextOptions<BlogAhmetContext> dbOptions { get; set; }

            private AppConfiguration settings { get; set; }

        }

        public static OptionsBuild ops = new OptionsBuild();






        public BlogAhmetContext(DbContextOptions<BlogAhmetContext> options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Admin> Admins { get; set; }

    }
}
