﻿using Common.Interfaces;

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
using Domain.Entities.Organization;

namespace Domain.Operations.Organization.Areas
{
    public class DeleteArea : Area, IDelete
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteAreaSetup.DeleteAreaAsync(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Area>
        {
            public Validation()
            {
                RuleFor(area => area.ID).NotNull();
              
            }
        }
    }
}
