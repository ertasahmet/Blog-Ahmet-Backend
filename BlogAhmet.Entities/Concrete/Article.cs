using BlogAhmet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Entities.Concrete
{
    public class Article : IEntity
    {

        public int ArticleId { get; set; }

        public string ArticleHeader { get; set; }

        public string ArticleContent { get; set; }

        public string ArticleImage { get; set; }

        public string ArticleCreatedAt { get; set; }

        public int ArticleNumberOfRead { get; set; }

        public int ArticleNumberOfComment { get; set; }

        public int CategoryId { get; set; }

    }
}
