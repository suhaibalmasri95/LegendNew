﻿using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    public class City : Country
    {


        [DBFiledName("ST_CNT_ID")]
        public long? CountryID { get; set; }
     
    }
}
