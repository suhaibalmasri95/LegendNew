﻿using System;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using FluentValidation;

namespace Domain.Operations.Production.Pricings
{
    public class DeletePricings : Pricing, IDelete
    {
        public long[] IDs;

        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }


            return await DeleteMode.DeletePricings(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Pricing>
        {
            public Validation()
            {


            }
        }
    }
}