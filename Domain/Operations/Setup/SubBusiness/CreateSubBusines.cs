using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.SubBusiness
{
    public class CreateSubBusines : SubLineOfBusnies, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBSubBusniesSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CreateSubBusines>
        {
            public Validation()
            {
                RuleFor(sub => sub.Name).NotEmpty();
                RuleFor(sub => sub.Name).MaximumLength(500);
                RuleFor(sub => sub.Name2).MaximumLength(500);
                RuleFor(sub => sub.Code).NotNull();
            
            }
        }

    }
}
