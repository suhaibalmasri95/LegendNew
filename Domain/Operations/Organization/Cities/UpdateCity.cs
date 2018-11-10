using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Cities
{
    public class UpdateCity : City, IUpdate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBCitySetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<City>
        {
            public Validation()
            {
                RuleFor(city => city.ID).NotNull();
                RuleFor(city => city.Name).NotEmpty();
                RuleFor(city => city.Name).MaximumLength(500);
                RuleFor(city => city.Name2).MaximumLength(500);
                RuleFor(city => city.Status).NotNull();
                RuleFor(city => city.CountryID).NotNull();
          
            }
        }
    }
}
