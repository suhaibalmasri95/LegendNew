using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using Domain.Operations.Setup.SubjectTypies;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Diagnosises
{
   public class DeleteDiagnosis : Diagnosis, IDelete
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBDeleteDiagnosisSetup.DeleteDiagnosisAsync(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Diagnosis>
        {
            public Validation()
            {
                RuleFor(subjectType => subjectType.ID).NotNull();
            }
        }
    }
}
