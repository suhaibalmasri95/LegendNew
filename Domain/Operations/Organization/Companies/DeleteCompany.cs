using Common.Interfaces;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Domain.Organization.Entities;

namespace Domain.Operations.Organization.Companies
{
    public class DeleteCompany : Company, IDelete
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteCompanySetup.DeleteCompanyAsync(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Company>
        {
            public Validation()
            {
                RuleFor(company => company.ID).NotNull();
              
            }
        }
    }
}
