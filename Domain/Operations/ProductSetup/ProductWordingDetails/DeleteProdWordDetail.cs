using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductWordingDetails
{
   public class DeleteProdWordDetail : Domain.Entities.ProductSetup.ProductWordingDetails, IDelete
    {

        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DbDeleteProdWordDetailSetup.DeleteProductWordingDetailAsync(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteProdWordDetail>
        {
            public Validation()
            {

            }
        }
    }
}
