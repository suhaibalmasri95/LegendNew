using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.ProductSetup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Operations.ProductSetup.ProductQuestionnaires
{
    public class UpdateProductQuestionears : ProductQuestionnaire,  IUpdate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await CreateUpdateProductQuestionearsSetup.AddUpdate(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<UpdateProductQuestionears>
        {
            public Validation()
            {
            }
        }
    }
}
