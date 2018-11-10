using Common.Interfaces;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Banks
{
    public class CreateBank : Bank, ICreate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBBankSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Bank>
        {
            public Validation()
            {
                RuleFor(bank => bank.Name).NotEmpty();
                RuleFor(bank => bank.Name).MaximumLength(500);
                RuleFor(bank => bank.Name2).MaximumLength(500);
                RuleFor(bank => bank.PhoneCode).MaximumLength(50);
                RuleFor(bank => bank.CurrencyCode).NotEmpty();
                RuleFor(bank => bank.Phone).MaximumLength(30);
              
            }
        }
    }
}
