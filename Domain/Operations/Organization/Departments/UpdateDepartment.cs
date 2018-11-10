using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Departments
{
    public class UpdateDepartment : Department, IUpdate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBDepartmentSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Department>
        {
            public Validation()
            {
                RuleFor(department => department.ID).NotNull();
                RuleFor(department => department.Name).NotEmpty();
                RuleFor(department => department.Name).MaximumLength(1000);
                RuleFor(department => department.Name2).MaximumLength(1000);
                RuleFor(department => department.Address).MaximumLength(1000);
                RuleFor(department => department.Email).MaximumLength(30);
                RuleFor(department => department.CompanyID).NotNull();
            }
        }
    }
}
