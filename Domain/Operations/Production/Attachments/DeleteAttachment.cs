﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using FluentValidation;

namespace Domain.Operations.Production.Attachments
{
    public class DeleteAttachment : Attachment, IDelete
    {
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            return await DeleteDbAttachmentSetup.DeleteAttachmentAsync(this);
        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<Attachment>
        {
            public Validation()
            {


            }
        }
    }
}
