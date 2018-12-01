using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System.Threading.Tasks;


namespace Domain.Operations.Setup.Diagnosises
{
    public class CreateDiagnosis : Diagnosis, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBDiagnosisSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CreateDiagnosis>
        {
            public Validation()
            {
            }
        }
    }
}
