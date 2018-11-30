using Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Counrties
{
    public class CreateCountry : Country, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBCountrySetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Country>
        {
            public Validation()
            {
                RuleFor(country => country.Name).NotEmpty();
                RuleFor(country => country.Name).MaximumLength(500);
                RuleFor(country => country.Name2).MaximumLength(500);
                RuleFor(country => country.Nationality).MaximumLength(100);
                RuleFor(country => country.CurrencyCode).MaximumLength(30);
                RuleFor(country => country.ReferenceNo).MaximumLength(500);
                RuleFor(country => country.Status).NotNull();
                RuleFor(country => country.PhoneCode).MaximumLength(50);
                RuleFor(country => country.Flag).MaximumLength(500);
            }
        }
    }
}
