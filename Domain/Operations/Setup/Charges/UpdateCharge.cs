using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Charges
{
    public class UpdateCharge : Charge, IUpdate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBChargeSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Charge>
        {
            public Validation()
            {
                RuleFor(charge => charge.ID).NotNull();
                RuleFor(charge => charge.Name).NotEmpty();
                RuleFor(charge => charge.Name).MaximumLength(500);
                RuleFor(charge => charge.Name2).MaximumLength(500);
                RuleFor(charge => charge.CreatedBy).NotNull();
                RuleFor(charge => charge.CreationDate).NotNull();

            }
        }

    }
}
