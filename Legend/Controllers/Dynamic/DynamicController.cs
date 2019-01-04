using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Entities.ProductDynamic;
using Domain.Operations.Dynamic;
using Domain.Operations.Organization.LockUps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Dynamic
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicController : ControllerBase
    {

        [Route("Load")]
        [HttpGet]
        public IActionResult Load(long? ID,long? DocumentID, long? CategoryID, long? ProductID, long? ProductDetailID, long? CategoryLevel , long? LineOfBuisness, long? SubLineOfBuisness, long? LangID )
        {


            GetDynamicCategory operation = new GetDynamicCategory();
            operation.ID = ID;
            operation.CategoryID = CategoryID;
            operation.ProductID = ProductID;
            operation.CategoryLevel = CategoryLevel;
            operation.LineOfBuisness = LineOfBuisness;
            operation.SubLineOfBuisness = SubLineOfBuisness;
            if (LangID.HasValue) { 
                operation.LangID = LangID;
            }
            else {
                LangID = 1;
                operation.LangID = 1;
            }
            var result = operation.QueryAsync().Result;

            var Categories = (List<ProductDynmicCategory>)result;
            foreach (var item in Categories)
            {
                item.ResultList = new List<DynamicDdl>();
                GetDynamicColumns columns = new GetDynamicColumns();
                columns.CategoryID = item.CategoryID;
                columns.ProductID = item.ProductID;
                columns.ProductDetailID = item.ProductDetailID;
                columns.ColumnType = null;
                columns.LineOfBuisness = item.LineOfBuisness;
                columns.SubLineOfBuisness = item.SubLineOfBuisness;
                columns.ExecludedColumn = 4;
                columns.ProductColumnID = null;
                columns.LangID = LangID;
                item.Columns = (List<ProductDynamicColumn>)columns.QueryAsyncInsert().Result;
                GetDynamicColumns dropDownList = new GetDynamicColumns();
                dropDownList.CategoryID = item.CategoryID;
                dropDownList.ProductID = item.ProductID;
                dropDownList.ProductDetailID = item.ProductDetailID;
                dropDownList.ColumnType = 4;
                dropDownList.LineOfBuisness = item.LineOfBuisness;
                dropDownList.SubLineOfBuisness = item.SubLineOfBuisness;
                dropDownList.ExecludedColumn = null;
                dropDownList.ProductColumnID = null;
                columns.LangID = LangID;
                item.Lists = (List<DynamicDdl>)dropDownList.QueryDllAsyncInsert().Result;
                item.OriginalList = item.Lists.ToList() ;
                item.ListWithChildren = item.Lists.ToList();
                foreach (var col in item.Lists)
                {
                    col.ChildrenIds = new List<long>();
                    if(col.ChildCounts > 0 && col.ParentID.HasValue)
                    {
                        foreach (var child in item.ListWithChildren)
                        {
                            if (child.ParentID == col.ID) { 
                                col.ChildrenIds.Add(child.ID.Value);
                                item.OriginalList.Remove(child);
                            }
                        }
                       
                    }
                    else if(col.ChildCounts > 0 && !col.ParentID.HasValue)
                    {
                        if (col.MajorCode.HasValue)
                        {
                            GetLockUps lockups = new GetLockUps();
                            lockups.LangID = LangID;
                            lockups.MajorCode = (long)col.MajorCode;

                            col.LockUps = (List<Lockup>)lockups.QueryAsync().Result;


                        }
                        foreach (var child in item.ListWithChildren)
                        {
                           
                            if (child.ParentID == col.ID) { 
                                col.ChildrenIds.Add(child.ID.Value);
                                item.OriginalList.Remove(child);
                            }
                        }
                    }
                    else
                    {
                        if (col.MajorCode.HasValue)
                        {
                            GetLockUps lockups = new GetLockUps();
                            lockups.LangID = LangID;
                            lockups.MajorCode = (long)col.MajorCode;

                            col.LockUps = (List<Lockup>)lockups.QueryAsync().Result;


                        }
                        if (!item.OriginalList.Contains(col))
                        item.OriginalList.Add(col);

                     
                    }
                  
                    /*if(col.ChildCounts > 0) { 
                    
                        // get children
                        col.ChildrenList =  
                        if (col.MajorCode.HasValue)
                        {
                            GetLockUps lockups = new GetLockUps();
                            lockups.LangID = LangID;
                            lockups.MajorCode =(long) col.MajorCode;

                            col.LockUps = (List<Lockup>)lockups.QueryAsync().Result;

                         
                        }
                        

                        col.ChildrenList = item.Lists.Where(p => p.ParentID == col.ID).ToList();

                        item.OriginalList = item.OriginalList.Except(col.ChildrenList).ToList();

                        item.ListWithChildren.Add(col);
                        
                    }
                    else {
                        GetLockUps lockups = new GetLockUps();
                        lockups.LangID = LangID;
                        lockups.MajorCode = (long)col.MajorCode;

                        col.LockUps = (List<Lockup>)lockups.QueryAsync().Result;
                        item.OriginalList.Add(col);
                    }*/
                }
                item.ListWithChildren = null;
                item.Lists = null;

            }




            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<ProductDynmicCategory>)result);
            }

        }
        [Route("LoadChild")]
        [HttpGet]
        public IActionResult LoadChild( [FromQuery]FilterClass filter)
        {




          
                GetDynamicColumns columns = new GetDynamicColumns();
                if (filter.LangID.HasValue)
                {
                    columns.LangID = filter.LangID;
                }
                else
                {
                    filter.LangID = 1;
                    columns.LangID = 1;
                }

            columns.ParentID = filter.parentID;
                var result = columns.QueryDllAsyncInsert().Result;

                List<DynamicDdl> list = (List<DynamicDdl>)result;
             
        
            foreach (var col in list)
            {

                col.milesecond = DateTime.Now.Millisecond;
                
                    if (col.MajorCode.HasValue)
                    {
                        GetLockUps lockups = new GetLockUps();
                        lockups.LangID = filter.LangID;
                        lockups.MajorCode =(long) col.MajorCode;
                        lockups.MinorCode = filter.MinorCode;

                        col.LockUps = (List<Lockup>)lockups.QueryAsync().Result;

                    }
            }







            return Ok(list);

        }
    }

    public class FilterClass
    {
        public long parentID { get; set; }
        public long? DocumentID { get; set; }
        public long MajorCode { get; set; }
        public long MinorCode { get; set; }
        public long? LangID { get; set; }
    }
}