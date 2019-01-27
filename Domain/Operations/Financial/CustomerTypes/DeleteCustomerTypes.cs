using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Financial;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerTypes
{
   public class DeleteCustomerTypes : CustomerType, IDelete
    {

        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DeleteMode.DeleteCustomerTypes(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CustomerType>
        {
            public Validation()
            {


            }
        }
    }
}