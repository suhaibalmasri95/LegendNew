using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DBFiledName : Attribute
    {
        public string Name;

        public DBFiledName (string name)
        {
            this.Name = name;
        }
            
    }
}
