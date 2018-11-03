using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Organization.Entities;

namespace Domain.Operations.Organization.Currencies
{
    public class DeleteCity : Currency, IDelete
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteCurrencySetup.DeleteCurrencyAsync(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Currency>
        {
            public Validation()
            {
                RuleFor(currency => currency.Code).NotNull();
              
            }
        }
    }
}
