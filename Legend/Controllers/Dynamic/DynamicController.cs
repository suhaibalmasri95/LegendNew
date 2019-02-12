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
            operation.ProductDetailID = ProductDetailID;
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
                item.childsData = new List<DynamicDdl>();
                item.ResultList = new List<DynamicDdl>();
                GetDynamicColumns columns = new GetDynamicColumns();
                columns.CategoryID = item.CategoryID;
                columns.ProductID = item.ProductID;
                columns.ProductDetailID = item.ProductDetailID;
                columns.ColumnType = null;
                columns.LineOfBuisness = item.LineOfBuisness;
                columns.SubLineOfBuisness = item.SubLineOfBuisness;
                // columns.ExecludedColumn = 4;
               //  columns.ProductColumnID = null;
                columns.LangID = LangID;
                item.Columns = (List<DynamicDdl>)columns.QueryAsyncInsert().Result;
              
                foreach (var col in item.Columns)
                {
                                          
                      if (col.MajorCode.HasValue)
                        {
                            GetLockUps lockups = new GetLockUps();
                            lockups.LangID = LangID;
                            lockups.MajorCode = (long)col.MajorCode;

                            col.LockUps = (List<Lockup>)lockups.QueryAsync().Result;
                        if(col.ParentID.HasValue)
                        {
                            col.OrginalLockUp = col.LockUps;
                            col.LockUps = new List<Lockup>();
                        }


                        }
                      
                 
                }
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

        [Route("LoadUpdate")]
        [HttpGet]
        public IActionResult LoadUpdate( long? DocumentID,long? RiskID, long? ProductID, long? ProductDetailID ,long? LangID)
        {


          
            GetDynamicColumns dropDownList = new GetDynamicColumns();

            dropDownList.ProductID = ProductID;
            dropDownList.UnderWritingDocID = DocumentID;
            dropDownList.UnderWritingRiskID = RiskID;
            dropDownList.ProductDetailID = ProductDetailID;
         
           
            if (LangID.HasValue)
            {
             
                dropDownList.LangID = LangID;
            }
            else
            {
                LangID = 1;
             
                dropDownList.LangID = 1;
            }
      

          
            var dropDownlistResult = dropDownList.QueryDllAsyncUpdate().Result;

            var List = (List<DynamicDdl>)dropDownlistResult;
            foreach (var col in List)
                {





                    if (col.MajorCode.HasValue)
                    {
                        GetLockUps lockups = new GetLockUps();
                        lockups.LangID = LangID;
                        lockups.MajorCode = (long)col.MajorCode;

                        col.LockUps = (List<Lockup>)lockups.QueryAsync().Result;

                    if (col.ParentID.HasValue)
                    {
                        col.OrginalLockUp = col.LockUps;
                        col.LockUps = new List<Lockup>();
                    }
                }





                }
                

            




         
                return Ok(List);
            

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