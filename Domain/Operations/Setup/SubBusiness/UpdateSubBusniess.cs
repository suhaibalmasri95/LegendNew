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
    public class UpdateSubBusniess : SubLineOfBusnies, IUpdate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBSubBusniesSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<UpdateSubBusniess>
        {
            public Validation()
            {
                RuleFor(sub => sub.Name).NotEmpty();
                RuleFor(sub => sub.Name).MaximumLength(500);
                RuleFor(sub => sub.Name2).MaximumLength(500);
                RuleFor(sub => sub.Code).NotNull();
            
            }
        }

    }
}
