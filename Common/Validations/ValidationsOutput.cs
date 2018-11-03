using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validations
{
    public class ValidationsOutput : IDTO
    {
        public bool IsValid;
        public List<ValidationItem> Errors;

        public ValidationsOutput()
        {
            Errors = new List<ValidationItem>();
        }
    }
}
