using BlogAhmet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Entities.Concrete
{
    public class Comment : IEntity
    {

        public int CommentId { get; set; }

        public string CommentNameSurname { get; set; }

        public string CommentEmail { get; set; }

        public string CommentContent { get; set; }

        public string CommentCreatedAt { get; set; }

        public bool CommentConfirmation { get; set; }

        public int ArticleId { get; set; }


    }
}
