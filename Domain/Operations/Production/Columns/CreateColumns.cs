using Common.Interfaces;
using Domain.Entities.ProductDynamic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Columns
{
    public class CreateColumns : ProductDynamicColumn ,ICreate
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
