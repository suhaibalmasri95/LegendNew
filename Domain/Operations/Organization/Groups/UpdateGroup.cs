using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Groups
{
   public class UpdateGroup : Group, IUpdate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBGroupSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Group>
        {
            public Validation()
            {
                RuleFor(group => group.ID).NotNull();
                RuleFor(group => group.Name).NotEmpty();
                RuleFor(group => group.Name).MaximumLength(1000);
                RuleFor(group => group.Name2).MaximumLength(1000);
                RuleFor(group => group.Status).NotNull();
                RuleFor(group => group.StatusDate).NotNull();
                RuleFor(group => group.IsPdf).NotNull();
                RuleFor(group => group.IsWord).NotNull();
                RuleFor(group => group.IsRef).NotNull();
                RuleFor(group => group.IsExcel).NotNull();
                RuleFor(group => group.IsExcelRecord).NotNull();
                RuleFor(group => group.Email).NotEmpty();
            }
        }
    }
}
