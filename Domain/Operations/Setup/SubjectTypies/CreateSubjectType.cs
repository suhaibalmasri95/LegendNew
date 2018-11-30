using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.SubjectTypies
{
    public class CreateSubjectType : SubjectType, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBSubjectTypeSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CreateSubjectType>
        {
            public Validation()
            {
                RuleFor(subType => subType.Name).NotEmpty();
                RuleFor(subType => subType.Name).MaximumLength(500);
                RuleFor(subType => subType.Name2).MaximumLength(500);
            }
        }
    }
}
