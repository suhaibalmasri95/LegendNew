using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_MENUS")]
    public class Menu : IEntity
    {
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("MENU_ORDER")]
        public long? Order { get; set; }
        [DBFiledName("MENU_TYPE")]
        public long? Type { get; set; }
        [DBFiledName("URL")]
        public string Url { get; set; }
        [DBFiledName("ST_MENUE_ID")]
        public long? SubMenuID { get; set; }
        [DBFiledName("FirstParentMenuID")]
        public long? FirstParentMenuID { get; set; }
        [DBFiledName("SecondParentMenuID")]
        public long? SecondParentMenuID { get; set; }
        [DBFiledName("ThirdParentMenuID")]
        public long? ThirdParentMenuID { get; set; }
    
    }
}
