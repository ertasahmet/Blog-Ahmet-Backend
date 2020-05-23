using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.Abstract
{
    public interface ICommentService
    {

        Comment Get(int id);
        List<Comment> GetAll();
        List<Comment> GetCommentsByArticle(int ArticleId);
        List<Comment> GetCommentsByConfirmation();
        List<Comment> GetCommentsByNotConfirmation();
        List<Comment> GetCommentsByContent(string commentContent);
        List<Comment> GetCommentsByContentNotConfirmation(string commentContent);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);

    }
}
