using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("ST_PRD_VALIDATIONS")]
    public class ProductColumnValidation : IEntity
    {
     
        [DBFiledName("NAME")]
    public string Name { get; set; }
    [DBFiledName("NAME2")]
    public string Name2 { get; set; }
    [DBFiledName("LangID")]
    public long? LangID { get; set; }

    [DBPrimaryKey]
    [DBFiledName("ID")]
    public long? ID { get; set; }

    [DBFiledName("LABLE")]
    public string Lable { get; set; }
    [DBFiledName("LABLE2")]
    public string Lable2 { get; set; }
    [DBFiledName("STATUS")]
    public long? Status { get; set; }
    [DBFiledName("STATUS_DATE")]
    public DateTime StatusDate { get; set; }

    [DBFiledName("COM_TYPE")]
    public long? ColumnType { get; set; }
 
    [DBFiledName("ST_CAT_ID")]
    public long? CategoryID { get; set; }
    [DBFiledName("RFE_TABLE_NAME")]
    public string RefTableName { get; set; }
    [DBFiledName("REF_MAJOR_CODE")]
    public string RefMajorCode { get; set; }
    [DBFiledName("REF_COL_DT_ID")]
    public string RefColDetailsID { get; set; }
    [DBFiledName("ST_PRD_CAT_ID")]
    public long? ProductCategoryID { get; set; }
    [DBFiledName("ST_COL_ID")]
    public long? ColumnID { get; set; }
    [DBFiledName("ST_PRD_ID")]
    public long? ProductID { get; set; }
    [DBFiledName("ST_PRDT_ID")]
    public long? ProductDetailID { get; set; }


        [DBFiledName("DATA_TYPE")]
        public long? DataType { get; set; }
        [DBFiledName("LOC_VALD_TYPE")]
        public long? LocValidType { get; set; }
        [DBFiledName("IS_MANDETORY")]
        public Int16? IsMandetory { get; set; }
        [DBFiledName("MAX_VALUE")]
        public long? MaxValue { get; set; }

        [DBFiledName("MIN_VALUE")]
        public long? MinValue { get; set; }
        [DBFiledName("CHECK_DUPLICATION")]
        public long? CheckDuplication { get; set; }
      

    }
}
