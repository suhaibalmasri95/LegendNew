using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Operations.ProductSetup.ProductColumns
{
  public  class DeleteProductColumns : Domain.Entities.ProductSetup.ProductColumns, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DbDeleteProdColumns.DeleteProductColumnsAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Domain.Entities.ProductSetup.ProductColumns>
        {
            public Validation()
            {

            }
        }
    }
}