using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductReports
{
    public class DeleteProductReports : Domain.Entities.ProductSetup.ProductReport, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DbDeleteProductReport.DeleteProductReportsAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteProductReports>
        {
            public Validation()
            {

            }
        }
    }
}
