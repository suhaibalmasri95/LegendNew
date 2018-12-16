using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductWordings
{
   public class DeleteProductWrodings : Domain.Entities.ProductSetup.ProductWording, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DbDeleteProductWording.DeleteProductWordingsAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteProductWrodings>
        {
            public Validation()
            {

            }
        }
    }
}
