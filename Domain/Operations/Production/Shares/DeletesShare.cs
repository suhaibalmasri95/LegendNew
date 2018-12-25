using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Shares
{
    public class DeletesShare : Share, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DeleteDbShareSetup.DeleteShareAsync(IDs);
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
