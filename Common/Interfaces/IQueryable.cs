using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IQueryable
    {
        Task<IEnumerable> Query();
    }
}
