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

namespace Domain.Operations.Organization.Cities
{
    public class DeleteCities : City, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DBDeleteCitySetup.DeleteCitiesAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<City>
        {
            public Validation()
            {
              
              
            }
        }
    }
}
