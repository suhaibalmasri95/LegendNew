using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.BankBranches
{
    public class UpdateBankBranch : BankBranch, IUpdate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBBankBranchSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<BankBranch>
        {
            public Validation()
            {
                RuleFor(BankBranch => BankBranch.ID).NotNull();
                RuleFor(BankBranch => BankBranch.Name).NotEmpty();
                RuleFor(BankBranch => BankBranch.Name).MaximumLength(500);
                RuleFor(BankBranch => BankBranch.Name2).MaximumLength(500);
                RuleFor(BankBranch => BankBranch.PhoneCode).MaximumLength(50);
                RuleFor(BankBranch => BankBranch.CurrencyCode).NotEmpty();
                RuleFor(BankBranch => BankBranch.Phone).MaximumLength(30);
                RuleFor(BankBranch => BankBranch.BankID).NotNull();
                RuleFor(BankBranch => BankBranch.CityID).NotNull();
                RuleFor(BankBranch => BankBranch.CountryID).NotNull();
            }
        }
    }
}
