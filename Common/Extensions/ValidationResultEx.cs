using Common.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Common.Extensions
{
    public static class ValidationResultEx
    {

        public static ValidationsOutput AsDto(this ValidationResult validation)
        {
            var output = new ValidationsOutput()
            {
                IsValid = validation.IsValid,
                Errors = validation.Errors.Select(error => new ValidationItem()
                {
                    EnglishMessage = error.ErrorMessage,
                    FieldName = error.PropertyName
                })
                .ToList()
            };
            return output;
        }
    }
}
