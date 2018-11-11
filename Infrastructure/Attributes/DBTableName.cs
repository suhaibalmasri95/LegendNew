using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Attributes
{
    public class DBTableName : Attribute
    {
        public string Name;
        public DBTableName(string name)
        {
            Name = name;
        }
    }
}
