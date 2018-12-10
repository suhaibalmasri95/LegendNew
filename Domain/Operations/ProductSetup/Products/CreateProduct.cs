using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.ProductSetup;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.Products
{
    public class CreateProduct : Product,  ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await CreateUpdateProductDBSetup.AddUpdate(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Product>
        {
            public Validation()
            {
            }
        }
    }
}
