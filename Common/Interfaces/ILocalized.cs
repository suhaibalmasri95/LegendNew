using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface ILocalized 
    {    
  
        string Name { get; set; }
     
        string Name2 { get; set; }
        long? LangID { get; set; }
    }
}
