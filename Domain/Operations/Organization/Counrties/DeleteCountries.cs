using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Counrties
{
    public class DeleteCountries : Country, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteCountrySetup.DeleteCountriesAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Country>
        {
            public Validation()
            {
                RuleFor(country => country.ID).NotNull();
              
            }
        }
    }
}
