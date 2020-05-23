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
    public class CommentManager : ICommentService
    {

        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }


        public void Add(Comment comment)
        {

            CommentValidator commentValidator = new CommentValidator();

            ValidationTool.Validate(commentValidator, comment);
            _commentDal.Add(comment);

        }

        public void Delete(Comment comment)
        {
            try
            {
                _commentDal.Delete(comment);
            }
            catch (Exception)
            {
                throw new Exception("Yorum silme gerçekleştirilemedi.");
            }
        }

        public Comment Get(int id)
        {
            return _commentDal.Get(a => a.CommentId == id);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public List<Comment> GetCommentsByArticle(int ArticleId)
        {
            return _commentDal.GetAll(c => c.ArticleId == ArticleId);
           // return _commentDal.GetAll(c => c.ArticleId == ArticleId & c.CommentConfirmation == true);
        }

        public List<Comment> GetCommentsByConfirmation()
        {
            return _commentDal.GetAll(c => c.CommentConfirmation == true);
        }

        public List<Comment> GetCommentsByNotConfirmation()
        {
            return _commentDal.GetAll(c => c.CommentConfirmation == false);
        }

        public List<Comment> GetCommentsByContent(string commentContent)
        {
            return _commentDal.GetAll(a => a.CommentContent.ToLower().Contains(commentContent.ToLower()));
            // return _commentDal.GetAll(a => a.CommentContent.ToLower().Contains(commentContent.ToLower()) & a.CommentConfirmation == true);
        }

        public List<Comment> GetCommentsByContentNotConfirmation(string commentContent)
        {
            return _commentDal.GetAll(a => a.CommentContent.ToLower().Contains(commentContent.ToLower()));
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
