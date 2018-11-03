using Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Organization.Entities;

namespace Domain.Operations.Organization.Currencies
{
    public class CreateCurrency : Currency, ICreate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBCurrencySetup.AddMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Currency>
        {
            public Validation()
            {
                RuleFor(currency => currency.Code).NotEmpty();
                RuleFor(currency => currency.Name).NotEmpty();
                RuleFor(currency => currency.Name).MaximumLength(500);
                RuleFor(currency => currency.Name2).MaximumLength(500);
                RuleFor(currency => currency.Sign).NotEmpty();
                RuleFor(currency => currency.Sign).MaximumLength(500);
                RuleFor(currency => currency.Status).NotNull();
                RuleFor(currency => currency.FractName).NotNull();
                RuleFor(currency => currency.FractName).MaximumLength(500);
                RuleFor(currency => currency.FractName2).NotNull();
                RuleFor(currency => currency.FractName2).MaximumLength(500);
            }
        }
    }
}
