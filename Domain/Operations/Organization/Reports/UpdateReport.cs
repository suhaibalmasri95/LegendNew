using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Reports
{
    public class UpdateReport : Report, IUpdate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await CreateUpdateReportDBSetup.AddUpdateMode(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        Task<IDTO> IOperation.Execute()
        {
            throw new NotImplementedException();
        }

        public class Validation : AbstractValidator<Report>
        {
            public Validation()
            {
                RuleFor(bank => bank.ID).NotEmpty();
                RuleFor(bank => bank.Name).NotEmpty();
                RuleFor(bank => bank.Name).MaximumLength(500);
                RuleFor(bank => bank.Name2).MaximumLength(500);
                RuleFor(bank => bank.Order).NotEmpty();
                RuleFor(bank => bank.Code).NotEmpty();
            }
        }
    }
}
