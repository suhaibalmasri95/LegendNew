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

namespace Domain.Operations.Organization.Banks
{
    public class DeleteBank : Bank, IDelete
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteBankSetup.DeleteBankAsync(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Bank>
        {
            public Validation()
            {
                RuleFor(bank => bank.ID).NotNull();
              
            }
        }
    }
}
