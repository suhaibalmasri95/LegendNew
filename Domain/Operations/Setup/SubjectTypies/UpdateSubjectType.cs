using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.SubjectTypies
{
    public class UpdateSubjectType : SubjectType, IUpdate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBSubjectTypeSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<UpdateSubjectType>
        {
            public Validation()
            {
                RuleFor(type => type.Name).NotEmpty();
                RuleFor(type => type.Name).MaximumLength(500);
                RuleFor(type => type.Name2).MaximumLength(500);
            
            }
        }
    }
}
