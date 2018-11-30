using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.AttributeGroups
{
    public class CreateAttributeGroup : AttributeGroup, ICreate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBActtributeGroupSetup.AddUpdateMode(this);
        }
        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }
        public class Validation : AbstractValidator<AttributeGroup>
        {
            public Validation()
            {        
            }
        }
    }
}
