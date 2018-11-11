using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Business
{
    public class CreateBusines : BusinesLine, ICreate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBBusniesSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CreateBusines>
        {
            public Validation()
            {
                RuleFor(area => area.Name).NotEmpty();
                RuleFor(area => area.Name).MaximumLength(500);
                RuleFor(area => area.Name2).MaximumLength(500);
                RuleFor(area => area.Code).NotNull();
                RuleFor(area => area.Module).NotNull();
                RuleFor(area => area.LangID).NotNull();
            }
        }

    }
}
