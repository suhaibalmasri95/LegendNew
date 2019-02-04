using Domain.Entities.Organization;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductDynamic
{
    public class DynamicDdl : ProductDynamicColumn
    {
        [DBFiledName("REF_MAJOR_CODE")]
        public decimal? MajorCode { get; set; }
        [DBFiledName("generatedTime")]
        public int milesecond { get; set; }
        [DBFiledName("children")]
        public List<DynamicDdl> ChildrenList { get; set; }
        [DBFiledName("Original")]
        public List<DynamicDdl> Original { get; set; }
        [DBFiledName("Lockups")]
        public List<Lockup> LockUps { get; set; }
        [DBFiledName("OrginalLockUp")]
        public List<Lockup> OrginalLockUp { get; set; }
        [DBFiledName("CHILDS_COUNT")]
        public decimal? ChildCounts { get; set; }


        [DBFiledName("childrenIDS")]
        public List<long> ChildrenIds { get; set; }
        [DBFiledName("ST_LOB_DESC")]
        public string LineDesc { get; set; }
        [DBFiledName("ST_SUB_LOB_DESC")]
        public string SubLineDesc { get; set; }
        [DBFiledName("COL_TYPE_DESC")]
        public string ColumnTypeDesc { get; set; }
        [DBFiledName("LOC_LEVEL_DESC")]
        public string LocLevelDesc { get; set; }
        [DBFiledName("ST_CAT_ID_DESC")]
        public string CategoryDesc { get; set; }
        [DBFiledName("ST_PRD_ID_DESC")]
        public string ProductDesc { get; set; }
        [DBFiledName("ST_COL_ID_DESC")]
        public string ColumnDesc { get; set; }
        [DBFiledName("ST_PRD_CLO_ID_DESC")]
        public string ProductColumnDesc { get; set; }


    }
}
