using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using FluentValidation;

namespace Domain.Operations.Production.Shares
{
    public class DeleteShare : Share, IDelete
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DeleteDbShareSetup.DeleteShareAsync(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Share>
        {
            public Validation()
            {


            }
        }
    }
}
