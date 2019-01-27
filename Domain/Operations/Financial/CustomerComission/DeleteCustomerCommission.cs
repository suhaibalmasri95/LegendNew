using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerComission
{
    public class DeleteCustomerCommission : Entities.Financial.CustomerCommission, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DeleteMode.DeleteCommissions(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Entities.Financial.CustomerCommission>
        {
            public Validation()
            {
          

            }
        }
    }
}
