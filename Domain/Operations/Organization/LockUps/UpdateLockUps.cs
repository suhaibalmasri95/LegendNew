using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Organization.Entities;

namespace Domain.Operations.Organization.LockUps
{
    public class UpdateLockUp : Lockup, IUpdate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBLockUpSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Lockup>
        {
            public Validation()
            {
                RuleFor(Lockup => Lockup.ID).NotNull();
                RuleFor(Lockup => Lockup.MajorCode).NotNull();
                RuleFor(Lockup => Lockup.MinorCode).NotNull();
                RuleFor(Lockup => Lockup.Name).NotEmpty();
                RuleFor(Lockup => Lockup.Name).MaximumLength(1000);
                RuleFor(Lockup => Lockup.Name2).MaximumLength(1000);
                RuleFor(Lockup => Lockup.CreatedBy).MaximumLength(500);
                RuleFor(Lockup => Lockup.CreationDate).NotNull();
            }
        }
    }
}
