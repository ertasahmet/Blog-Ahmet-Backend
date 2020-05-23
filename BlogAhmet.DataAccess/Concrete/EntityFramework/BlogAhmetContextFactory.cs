using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.DataAccess.Concrete.EntityFramework
{
    public class BlogAhmetContextFactory : IDesignTimeDbContextFactory<BlogAhmetContext>
    {

        public BlogAhmetContext CreateDbContext(string[] args)
        {

            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<BlogAhmetContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new BlogAhmetContext(opsBuilder.Options); 

        }

     

    }
}
