using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.Abstract
{
    public interface IArticleService
    {

        Article Get(int id);
        List<Article> GetAll();
        List<Article> GetArticlesByCategory(int categoryId);
        List<Article> GetArticlesByArticleName(string ArticleName);
        void Add(Article article);
        void Update(Article article);
        void Delete(Article article);
        int GetNumberOfRead(int articleId);
        int GetNumberOfComment(int articleId);

    }
}
