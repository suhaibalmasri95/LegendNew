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
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.MenuDetails
{   
    public class DeleteMenus : Menu, IDelete
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            throw new NotImplementedException();
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteMenus>
        {
            public Validation()
            {
                RuleFor(area => area.ID).NotNull();
            }
        }
    }
}
