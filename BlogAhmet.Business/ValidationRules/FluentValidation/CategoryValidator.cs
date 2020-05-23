using BlogAhmet.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {

        public CategoryValidator()
        {


            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategori ismi boş olamaz.");
 

        }

    }
}
