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

namespace Domain.Operations.Organization.CompanyBranches
{
    public class DeleteCities : CompanyBranch, IDelete
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteCompanyBranchSetup.DeleteCompanyBranchAsync(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CompanyBranch>
        {
            public Validation()
            {
                RuleFor(companyBranch => companyBranch.ID).NotNull();

            }
        }
    }
}
