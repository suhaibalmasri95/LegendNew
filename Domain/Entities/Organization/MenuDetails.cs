using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    public class Menu : IEntity
    {
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("MENU_ORDER")]
        public string Order { get; set; }
        [DBFiledName("MENU_TYPE")]
        public string Type { get; set; }
        [DBFiledName("URL")]
        public string Url { get; set; }
        [DBFiledName("ST_MENUE_ID")]
        public long? SubMenuID { get; set; }
    }
}
