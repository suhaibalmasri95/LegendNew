using Common.Interfaces;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Organization.Entities;

namespace Domain.Operations.Organization.Companies
{
    public class CreateCompany : Company, ICreate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBCompanySetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Company>
        {
            public Validation()
            {
                RuleFor(company => company.Name).NotEmpty();
                RuleFor(company => company.Name).MaximumLength(500);
                RuleFor(company => company.Name2).MaximumLength(500);
                RuleFor(company => company.Phone).NotEmpty();
                RuleFor(company => company.Phone).MaximumLength(30);
                RuleFor(company => company.CurrencyCode).MaximumLength(30);
                RuleFor(company => company.Mobile).MaximumLength(30);
                RuleFor(company => company.Fax).MaximumLength(30);
                RuleFor(company => company.Email).MaximumLength(30);
                RuleFor(company => company.Website).MaximumLength(30);
                RuleFor(company => company.Address).MaximumLength(30);
                RuleFor(company => company.Address2).MaximumLength(30);
                RuleFor(company => company.ContactPerson).MaximumLength(30);
                RuleFor(company => company.Code).MaximumLength(30);
             
            
            }
        }
    }
}
