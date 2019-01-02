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
    public class CreateRisk 
    {
        public List<Risk> Risks { get; set; }
        public async Task<IDTO> ExecuteAsync()
        {
          
        
            return await DBRiskSetup.AddUpdateMode(Risks);
        }

     

    }
}
