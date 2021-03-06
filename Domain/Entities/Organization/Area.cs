﻿using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_AREAS")]
    public class Area : City
    {
        [DBFiledName("ST_CTY_ID")]
        public long? CityID { get; set; }
    }
}
