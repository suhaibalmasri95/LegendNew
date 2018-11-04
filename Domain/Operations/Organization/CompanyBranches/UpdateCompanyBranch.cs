using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Organization.Entities;

namespace Domain.Operations.Organization.CompanyBranches
{
    public class UpdateCompanyBranch : CompanyBranch, IUpdate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBCompanyBranchSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<CompanyBranch>
        {
            public Validation()
            {
                RuleFor(comapnyBranch => comapnyBranch.ID).NotNull();
                RuleFor(comapnyBranch => comapnyBranch.Name).NotEmpty();
                RuleFor(comapnyBranch => comapnyBranch.Name).MaximumLength(1000);
                RuleFor(comapnyBranch => comapnyBranch.Name2).MaximumLength(1000);
                RuleFor(comapnyBranch => comapnyBranch.CompanyID).NotNull();
                RuleFor(comapnyBranch => comapnyBranch.Phone).MaximumLength(30);
                RuleFor(comapnyBranch => comapnyBranch.CurrencyCode).MaximumLength(30);
                RuleFor(comapnyBranch => comapnyBranch.Fax).MaximumLength(30);
                RuleFor(comapnyBranch => comapnyBranch.Email).MaximumLength(30);
                RuleFor(comapnyBranch => comapnyBranch.Address).MaximumLength(30);
                RuleFor(comapnyBranch => comapnyBranch.Address2).MaximumLength(30);
                RuleFor(comapnyBranch => comapnyBranch.Code).MaximumLength(30);
            }
        }
    }
}
