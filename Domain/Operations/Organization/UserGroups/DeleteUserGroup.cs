using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.UserGroups
{
    public class DeleteUserGroup : UserGroup, IDelete
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteUserGroupSetup.DeleteUserGroupAsync(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }
        public class Validation : AbstractValidator<UserGroup>
        {
            public Validation()
            {
                RuleFor(userGroup => userGroup.ID).NotNull();

            }
        }
    }
}
