﻿using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductWordingDetails
{
    public class DeleteProdWordDetails : Domain.Entities.ProductSetup.ProductWordingDetails, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DbDeleteProdWordDetailSetup.DeleteProductWordingDetailsAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteProdWordDetails>
        {
            public Validation()
            {

            }
        }
    }
}
