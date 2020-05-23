using BlogAhmet.DataAccess.Abstract;
using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAhmet.DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article>, IArticleDal
    {
        public int GetNumberOfComment(int articleId)
        {
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {

                return context.Articles.Where(a => a.ArticleId == articleId).SingleOrDefault().ArticleNumberOfComment;
            }
        }

        public int GetNumberOfRead(int articleId)
        {
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {

                return context.Articles.Where(a => a.ArticleId == articleId).SingleOrDefault().ArticleNumberOfRead;
            }
        }


    }
}
