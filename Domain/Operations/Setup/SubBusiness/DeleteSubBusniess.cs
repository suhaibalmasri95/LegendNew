using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.SubBusiness
{
    public class DeleteSubBusniess : SubLineOfBusnies, IDelete
    {
       
    public async Task<IDTO> Execute()
    {
        var validationResult = (ValidationsOutput)Validate();
        if (!validationResult.IsValid)
        {
            return validationResult;
        }
        return await DBDeleteSubBusinessSetup.DeleteSubLineOfBusniessLineAsync(this);
    }

    public IDTO Validate()
    {
        return new Validation().Validate(this).AsDto();
    }

    public class Validation : AbstractValidator<SubLineOfBusnies>
    {
        public Validation()
        {

                RuleFor(subLineOfBusnies => subLineOfBusnies.ID).NotNull();
            }
    }
}
}
