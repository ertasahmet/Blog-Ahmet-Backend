using BlogAhmet.Business.Abstract;
using BlogAhmet.Business.Utilities;
using BlogAhmet.Business.ValidationRules.FluentValidation;
using BlogAhmet.DataAccess.Abstract;
using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.Concrete
{
    public class ArticleManager : IArticleService
    {

        private IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void Add(Article article)
        {

            ArticleValidator articleValidator = new ArticleValidator();

            ValidationTool.Validate(articleValidator, article);
            _articleDal.Add(article);

        }

        public void Delete(Article article)
        {
            try
            {
                _articleDal.Delete(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Makale silme gerçekleştirilemedi.");
            }
        }

        public Article Get(int id)
        {
            return _articleDal.Get(a => a.ArticleId == id);
        }

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }

        public List<Article> GetArticlesByArticleName(string ArticleName)
        {
            return _articleDal.GetAll(a => a.ArticleHeader.ToLower().Contains(ArticleName.ToLower()));
        }

        public List<Article> GetArticlesByCategory(int categoryId)
        {
            return _articleDal.GetAll(a => a.CategoryId == categoryId);
        }

        public int GetNumberOfComment(int articleId)
        {
            return _articleDal.GetNumberOfComment(articleId);
        }

        public int GetNumberOfRead(int articleId)
        {
            return _articleDal.GetNumberOfRead(articleId);
        }

        public void Update(Article article)
        {
            _articleDal.Update(article);
        }
    }
}
