using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Categories
{
    public class CreateCategory : Category, ICreate
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await CategoryCreateUpdateSetup.AddUpdate(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Category>
        {
            public Validation()
            {
            }
        }
    }
}
