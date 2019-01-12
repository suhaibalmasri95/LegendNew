using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Financial;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.Customers
{
    public class CreateCustomer : Customer, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await AddUpdateCustomer.AddUpdateMode(this, this.AddUpdate);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Customer>
        {
            public Validation()
            {


            }
        }
    }
}
