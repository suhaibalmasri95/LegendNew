using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Areas
{
    public class UpdateArea : Area, IUpdate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBAreaSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Area>
        {
            public Validation()
            {
                RuleFor(area => area.ID).NotNull();
                RuleFor(area => area.Name).NotEmpty();
                RuleFor(area => area.Name).MaximumLength(500);
                RuleFor(area => area.Name2).MaximumLength(500);
                RuleFor(area => area.Status).NotNull();
                RuleFor(area => area.CountryID).NotNull();
                RuleFor(area => area.CityID).NotNull();
            }
        }
    }
}
