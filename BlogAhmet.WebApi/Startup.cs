using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using BlogAhmet.Business.Abstract;
using BlogAhmet.Business.Concrete;
using BlogAhmet.Business.Utilities;
using BlogAhmet.DataAccess.Abstract;
using BlogAhmet.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlogAhmet.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddCors();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // DEPENDENCY INJECTION
            // ----------------------------------------------------------------------

            services.AddSingleton<IArticleService, ArticleManager>();
            services.AddSingleton<IArticleDal, EfArticleDal>();

            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDal, EfCategoryDal>();

            services.AddSingleton<ICommentService, CommentManager>();
            services.AddSingleton<ICommentDal, EfCommentDal>();


            // ----------------------------------------------------------------------

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

          //  services.AddDbContext<BlogAhmetContext>(options => options.UseSqlServer(Configuration["DbConnection"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();


        }
    }
}
