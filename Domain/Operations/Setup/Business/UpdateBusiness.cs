using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Business
{
    public class UpdateBusiness : BusinessLine, IUpdate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBBusinessSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<UpdateBusiness>
        {
            public Validation()
            {
                RuleFor(area => area.Name).NotEmpty();
                RuleFor(area => area.Name).MaximumLength(500);
                RuleFor(area => area.Name2).MaximumLength(500);
                RuleFor(area => area.Code).NotNull();
                RuleFor(area => area.Module).NotNull();
                RuleFor(area => area.LangID).NotNull();
            }
        }

    }
}
