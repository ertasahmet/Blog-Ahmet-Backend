using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.Utilities
{
    public static class ValidationTool
    {

        public static void Validate(IValidator validator, object entity)
        {
            // Bu şekilde yapıp hata olduğunda Validation hatası fırlatıyoruz.
            //  var result = productValidator.Validate(product);
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }

        }

    }
}
