using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Operations
{
    public class ComplateOperation<T> : IDTO
    {
        public string message;
        public T Data;
        public long? ID;
    }
}
