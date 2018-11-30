using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Users
{
   public class UpdateUser : User , IUpdate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBUserSetup.UpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<User>
        {
            public Validation()
            {
                RuleFor(user => user.ID).NotNull();
                RuleFor(user => user.Name).NotEmpty();
                RuleFor(user => user.UserName).NotEmpty();
                RuleFor(user => user.EffectiveDate).NotNull();
                RuleFor(user => user.ExpiryDate).NotNull();
                RuleFor(user => user.Status).NotNull();
                RuleFor(user => user.StatusDate).NotNull();
                RuleFor(user => user.Password).NotNull();
                RuleFor(user => user.Email).NotNull();
                RuleFor(user => user.CreatedBy).NotNull();
                RuleFor(user => user.CreationDate).NotNull();
                RuleFor(user => user.Name).MaximumLength(500);
                RuleFor(user => user.Name2).MaximumLength(500);
            }
        }
    }
}
