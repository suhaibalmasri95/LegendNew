using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerRelation
{
  public  class CreateCustomerRelation : Entities.Financial.CustomerRelation, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await AddUpdateMode.AddUpdate(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Entities.Financial.CustomerRelation>
        {
            public Validation()
            {


            }
        }
    }
}