﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Production
{
    public class CustomerShare
    {
        public long? CustomerID { get; set; }
        public long? shareType { get; set; }
        public double? Commision { get; set; }
        public long? ShareID { get; set; }
    
    }
}
