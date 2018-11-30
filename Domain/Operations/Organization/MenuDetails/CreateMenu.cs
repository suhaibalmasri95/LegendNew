using Common.Interfaces;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.MenuDetails
{
    public class CreateMenu : Menu, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBMenuSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CreateMenu>
        {
            public Validation()
            {
                RuleFor(menu => menu.Name).NotEmpty();
                RuleFor(menu => menu.Name).MaximumLength(500);
                RuleFor(menu => menu.Name2).MaximumLength(500);
            }
        }
    }
}
