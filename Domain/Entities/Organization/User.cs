using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_USERES")]
    public class User : IEntity
    {
        public User()
        {
            StatusDate = DateTime.Now;
            CreationDate = DateTime.Now;
            UserRelations = new List<UserGroup>();
        }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("USERNAME")]
        public string UserName { get; set; }
        [DBFiledName("EFF_DATE")]
        public DateTime EffectiveDate { get; set; }
        [DBFiledName("EXPIRY_DATE")]
        public DateTime ExpiryDate { get; set; }
        [DBFiledName("LOCK_STATUS")]
        public long Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("PASSWORD")]
        public string Password { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
        [DBFiledName("ST_COM_ID")]
        public long CompanyID { get; set; }
        [DBFiledName("UserRelations")]
        public List<UserGroup> UserRelations { get; set; }
        [DBFiledName("BIRTH_DATE")]
        public DateTime BirthDate { get; set; }
        [DBFiledName("Picture")]
        public string Picture { get; set; }
        [DBFiledName("COUNTRY_CODE")]
        public long CountryID { get; set; }
        [DBFiledName("MOBILE")]
        public string Mobile { get; set; }
        [DBFiledName("LOCKUP_TYPE")]
        public long UserType { get; set; }
        [DBFiledName("NO_OF_LOGIN")]
        public long NoOfLogin { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime? CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime? ModificationDate { get; set; }
    }
}
