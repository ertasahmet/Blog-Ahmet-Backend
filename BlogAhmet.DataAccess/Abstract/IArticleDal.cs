using BlogAhmet.Entities.Abstract;
using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace BlogAhmet.DataAccess.Abstract
{
    public interface IArticleDal : IEntityRepository<Article>
    {

        int GetNumberOfRead(int articleId);
        int GetNumberOfComment(int articleId);


    }
}
