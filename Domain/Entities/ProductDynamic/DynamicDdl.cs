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

        [DBFiledName("CHILDS_COUNT")]
        public decimal? ChildCounts { get; set; }


        [DBFiledName("childrenIDS")]
        public List<long> ChildrenIds { get; set; }
    }
}
