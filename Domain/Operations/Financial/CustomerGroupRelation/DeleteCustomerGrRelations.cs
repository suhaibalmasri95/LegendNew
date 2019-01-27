using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerGroupRelation
{
   public class DeleteCustomerGrRelations : Entities.Financial.CustomerGroupRelation, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DeleteMode.DeleteGrRelations(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Entities.Financial.CustomerGroupRelation>
        {
            public Validation()
            {


            }
        }
    }
}