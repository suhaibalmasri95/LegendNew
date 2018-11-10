using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Areas;

namespace Domain.Operations.Organization.MenuDetails
{
    public class UpdateMenu : Menu, IUpdate
    {
        public async Task<IDTO> Execute()
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

        public class Validation : AbstractValidator<UpdateMenu>
        {
            public Validation()
            {
                RuleFor(area => area.ID).NotNull();
                RuleFor(area => area.Name).NotEmpty();
                RuleFor(area => area.Name).MaximumLength(500);
                RuleFor(area => area.Name2).MaximumLength(500);
            }
        }
    }
}
