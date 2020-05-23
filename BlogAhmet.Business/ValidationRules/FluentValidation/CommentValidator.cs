using BlogAhmet.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {

        public CommentValidator()
        {

            RuleFor(p => p.CommentNameSurname).NotEmpty().WithMessage("Ad Soyad boş olamaz.");

            RuleFor(p => p.CommentContent).NotEmpty().WithMessage("Yorum içeriği boş olamaz.");

            RuleFor(p => p.CommentEmail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin.");



        }

    }
}
