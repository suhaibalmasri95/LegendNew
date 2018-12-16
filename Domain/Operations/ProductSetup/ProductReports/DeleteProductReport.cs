using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductReports
{
    public class DeleteProductReport : Domain.Entities.ProductSetup.ProductReport, IDelete
    {
     
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DbDeleteProductReport.DeleteProducReportAsync(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteProductReport>
        {
            public Validation()
            {

            }
        }
    }
}
