using Common.Interfaces;
using Infrastructure.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_MENUS")]
    public class Menu : IEntity
    {
        public Menu()
        {
            children = new List<Menu>();
            
        }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("")]
        public string text => Name;
        [DBFiledName("")]
        public long? value => ID;
       
          

        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("GroupRelationID")]
        public long GroupRelationID { get; set; }
        [DBFiledName("MENU_ORDER")]
        public long? Order { get; set; }
        [DBFiledName("MENU_TYPE")]
        public long? Type { get; set; }
        [DBFiledName("URL")]
        public string Url { get; set; }
        [DBFiledName("ST_MENUE_ID")]
        public long? SubMenuID { get; set; }
        [DBFiledName("SystemMenuID")]
        public long? SystemMenuID { get; set; }
        [DBFiledName("SystemMenuName")]
        public string SystemMenuName { get; set; }
        [DBFiledName("SecondParentMenuID")]
        public long? ModuleMenuID { get; set; }
        [DBFiledName("ModuleMenuName")]
        public string ModuleMenuName { get; set; }
        [DBFiledName("ThirdParentMenuID")]
        public long? SubModuleMenuID { get; set; }
        [DBFiledName("SubMoudleMenuName")]
        public string SubModuleMenuName { get; set; }
        [DBFiledName("FourthParentMenuID")]
        public long? PageMenuID { get; set; }
        [DBFiledName("SubMoudleMenuName")]
        public string PageMenuName { get; set; }
        [DBFiledName("FourthParentMenuID")]
        public long? ActionMenuID { get; set; }
        [DBFiledName("SubMoudleMenuName")]
        public string ActionMenuName { get; set; }
        [DBFiledName("")]
        public List<Menu> children { get; set; }
        [DBFiledName("")]
        public Menu Parent { get; set; }
        [DBFiledName("")]
        [JsonProperty(PropertyName = "checked")]
        public bool isChecked { get; set; } = false;
}
}
