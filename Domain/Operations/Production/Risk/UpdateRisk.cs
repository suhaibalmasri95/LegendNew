using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Risks
{
   public class UpdateRisk : Risk, IUpdate
    {
        public List<Risk> Risks { get; set; }
        public async Task<IDTO> ExecuteAsync()
        {
          
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBRiskSetup.AddUpdateMode(Risks);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Risk>
        {
            public Validation()
            {


            }
        }

    }
}
