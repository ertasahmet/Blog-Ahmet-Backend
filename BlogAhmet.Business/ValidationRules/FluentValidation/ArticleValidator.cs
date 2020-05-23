using BlogAhmet.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.ValidationRules.FluentValidation
{
    public class ArticleValidator : AbstractValidator<Article>
    {

        public ArticleValidator()
        {
            // Not empty fonksiyonu alanın boş geçilemez olduğunu gösteriyor. WithMessage ile mesaj gönderebiliriz.
           
            RuleFor(a => a.ArticleContent).NotEmpty().WithMessage("Makale içeriği boş olamaz.");

            RuleFor(a => a.ArticleHeader).NotEmpty().WithMessage("Makale başlığı boş olamaz.");

        }

    }
}
