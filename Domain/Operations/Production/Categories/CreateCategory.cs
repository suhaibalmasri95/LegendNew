using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Categories
{
    public class CreateCategory : ICreate
    {
        public Task<IDTO> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public IDTO Validate()
        {
            throw new NotImplementedException();
        }
    }
}
