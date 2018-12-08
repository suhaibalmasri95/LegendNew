using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Questionears
{
    public class DeleteProductQuestionears  : ProductQuestion, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBDeleteProductQuestionearsSetup.DeleteMultipleProductSubjectTypeAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteProductQuestionears>
        {
            public Validation()
            {
                RuleFor(x => x.IDs.Length > 0);
            }
        }
    }
}
