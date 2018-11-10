using Common.Interfaces;
using FluentValidation;
using Common.Extensions;
using Common.Validations;
using System.Threading.Tasks;
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Departments
{
    public class DeleteDepartment : Department, IDelete
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DBDeleteDepartmentSetup.DeleteDepartmentAsync(this);
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
            }
        }
    }
}
