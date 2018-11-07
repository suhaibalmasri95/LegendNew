using Common.Extensions;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.GroupRelations
{
    public class CreateGroupRelation : GroupRelation, ICreate
    {
        public async Task<IDTO> Execute()
        {
            var validationResult = (ValidationsOutput)Validate();
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await DBGroupRelationSetup.AddUpdateMode(this);

        }

        public IDTO Validate()
        {
            return new Validation().Validate(this).AsDto();
        }

        public class Validation : AbstractValidator<GroupRelation>
        {
            public Validation()
            {
                RuleFor(groupRelation => groupRelation.GroupID).NotNull();
                RuleFor(groupRelation => groupRelation.GroupName).NotEmpty();
                RuleFor(groupRelation => groupRelation.GroupName).MaximumLength(1000);
                RuleFor(groupRelation => groupRelation.LockUpGroupCat).NotNull();
                RuleFor(groupRelation => groupRelation.RefrenceID).NotNull();
               
            }
        }
    }
}
