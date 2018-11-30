using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.UserGroups
{
    public class CreateUserGroup : UserGroup, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBUserGroupSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }
        public class Validation : AbstractValidator<UserGroup>
        {
            public Validation()
            {
                RuleFor(userGroup => userGroup.UserID).NotNull();
                RuleFor(userGroup => userGroup.UserName).NotNull();
              


            }
        }
    }
}
