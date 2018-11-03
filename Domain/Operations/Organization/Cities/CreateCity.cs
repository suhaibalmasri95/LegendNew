using Common.Interfaces;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Organization.Entities;

namespace Domain.Operations.Organization.Cities
{
    public class CreateCity : City, ICreate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBCitySetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<City>
        {
            public Validation()
            {
                RuleFor(city => city.Name).NotEmpty();
                RuleFor(city => city.Name).MaximumLength(500);
                RuleFor(city => city.Name2).MaximumLength(500);
                RuleFor(city => city.ReferenceNo).MaximumLength(500);
                RuleFor(city => city.Status).NotNull();
                RuleFor(city => city.Status).NotNull();
                RuleFor(city => city.CountryID).NotNull();
            }
        }
    }
}
