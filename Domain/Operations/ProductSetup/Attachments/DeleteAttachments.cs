using Common.Extensions;
using Common.Interfaces;
using Common.Operations;
using Common.Validations;
using FluentValidation;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.Attachments
{
  public  class DeleteAttachments : Domain.Entities.ProductSetup.Attachment, IDelete
    {
        public long[] IDs;
        public async Task<IDTO> ExecuteAsync()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DbDeleteAttachmentSetup.DeleteAttachmentsAsync(IDs);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<DeleteAttachments>
        {
            public Validation()
            {

            }
        }
    }
}
