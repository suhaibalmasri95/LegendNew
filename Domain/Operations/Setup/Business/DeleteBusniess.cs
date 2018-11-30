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
    public class DeleteBusniess : BusinessLine, IDelete
    {
        public async Task<IDTO> ExecuteAsync()
    {
        var validationResult = (ValidationsOutput)Validate();
        if (!validationResult.IsValid)
        {
            return validationResult;
        }
        return await DBDeleteBusniessSetup.DeleteBusinessLineAsync(this);
    }

    public IDTO Validate()
    {
        return new Validation().Validate(this).AsDto();
    }

    public class Validation : AbstractValidator<BusinessLine>
    {
        public Validation()
        {
            RuleFor(businessLine => businessLine.ID).NotNull();

        }
    }
}
}
