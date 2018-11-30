﻿using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Attributes
{
    public class DeleteAttribute : Acttribute, IDelete
    {
        public async Task<IDTO> Execute()
    {
        var validationResult = (ValidationsOutput)Validate();
        if (!validationResult.IsValid)
        {
            return validationResult;
        }
        return await DBDeleteAttributesSetup.DeleteAttributeAsync(this);
    }

    public IDTO Validate()
    {
        return new Validation().Validate(this).AsDto();
    }

    public class Validation : AbstractValidator<Acttribute>
    {
        public Validation()
        {
        }
    }
}
}
