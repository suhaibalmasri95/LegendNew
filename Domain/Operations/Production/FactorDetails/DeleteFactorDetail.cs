﻿using System;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using FluentValidation;

namespace Domain.Operations.Production.FactorDetails
{
    public class DeleteFactorDetail : FactorDetail, IDelete
    {

        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DeleteMode.DeleteFactorDetail(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<FactorDetail>
        {
            public Validation()
            {


            }
        }
    }
}
