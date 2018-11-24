using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Operations.Organization.GroupRelations;
using Domain.Operations.Organization.MenuDetails;
using Domain.Operations.Organization.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupRelationController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateGroupRelation operation)
        {
            var result = operation.Execute().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }

        [Route("Update")]
        [HttpPost]
        public IApiResult Update(UpdateGroupRelation operation)
        {
            var result = operation.Execute().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }

        [Route("Load")]
        [HttpGet]
        public IActionResult Load(Int64 ID ,Int64? groupID, Int64? langId)
        {

            GetGroupRelation operation = new GetGroupRelation();

            operation.ID = ID;
            operation.GroupID = groupID;
            if (langId.HasValue)
                operation.LangID = langId;
            else
                operation.LangID = 1;

            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<GroupRelation>)result);
            }

        }
        [Route("LoadActions")]
        [HttpGet]
        public IActionResult LoadActions(long? groupID, long? LanguageID)
        {
            GetGroupRelation operation = new GetGroupRelation();
            GetMenus getMenus = new GetMenus();
            getMenus.Type = 5;

            operation.GroupID = groupID;

            if (LanguageID.HasValue)
            {
                operation.LangID = LanguageID;
                getMenus.LangID = LanguageID;
            }
            else
            {
                operation.LangID = 1;
                getMenus.LangID = 1;

            }
               
            var result = operation.QueryAsync().Result;
            var Actions = (List<Menu>)getMenus.QueryAsync().Result;
            var groups = (List<GroupRelation>)result;
            List<Menu> returnedRelatedActions = new List<Menu>();
            List<Menu> returnedUnRelatedActions = new List<Menu>();
            if (groups.Count > 0) { 
            foreach (var item in Actions)
            {
                    foreach (var group in groups)
                    {
                        if (group.RefrenceID == item.ID)
                        {
                            bool alreadyExist = returnedRelatedActions.Contains(item);
                            bool alreadyExistInSecondList = returnedUnRelatedActions.Contains(item);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {
                                item.GroupRelationID = group.ID.Value;
                                returnedRelatedActions.Add(item);
                            }
                            else
                            {
                                item.GroupRelationID = group.ID.Value;
                                returnedRelatedActions.Add(item);
                                returnedUnRelatedActions.Remove(item);
                            }
                        }
                        else
                        {
                            bool alreadyExist = returnedUnRelatedActions.Contains(item);
                            bool alreadyExistInFirstList = returnedRelatedActions.Contains(item);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {
                                item.GroupRelationID = group.ID.Value;
                                returnedUnRelatedActions.Add(item);
                            }
                        }
                    }

            }
            }
            else
            {
                returnedUnRelatedActions = Actions;
            }
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedActions = returnedRelatedActions, UnRelatedActions = returnedUnRelatedActions });
            }
        }
        [Route("LoadReports")]
        [HttpGet]
        public IActionResult LoadReports(long? groupID, long? reportID, long? LanguageID)
        {
            GetGroupRelation operation = new GetGroupRelation();
            GetReport getRelatedReport = new GetReport();
            operation.GroupID = groupID;
            GetReport getUnRelatedReport = new GetReport();
            if (LanguageID.HasValue)
            {
                operation.LangID = LanguageID;
                getRelatedReport.LangID = LanguageID;
                getUnRelatedReport.LangID = LanguageID;
            }
            else { 
                operation.LangID = 1;
                getUnRelatedReport.LangID = 1;
                getRelatedReport.LangID = 1;
            }
          
            var Reports = (List<Report>)getRelatedReport.QueryAsync().Result;

            var result = operation.QueryAsync().Result;
            var reports = (List<GroupRelation>)result;
         
            List<Report> returnedRelatedReports = new List<Report>();
            List<Report> returnedUnRelatedReports= new List<Report>();
            
            var groups = (List<GroupRelation>)result;
            if (groups.Count > 0)
            {
                foreach (var item in Reports)
                {
                    foreach (var group in groups)
                    {
                        if (group.RefrenceID == item.ID)
                        {
                            bool alreadyExist = returnedRelatedReports.Contains(item);
                            bool alreadyExistInSecondList = returnedUnRelatedReports.Contains(item);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {
                                item.ReportRelationID = group.ID.Value;
                                returnedRelatedReports.Add(item);
                            }
                            else
                            {
                                item.ReportRelationID = group.ID.Value;
                                returnedRelatedReports.Add(item);
                                returnedUnRelatedReports.Remove(item);
                            }
                        }
                        else
                        {
                            bool alreadyExist = returnedUnRelatedReports.Contains(item);
                            bool alreadyExistInFirstList = returnedRelatedReports.Contains(item);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {
                                item.ReportRelationID = group.ID.Value;
                                returnedUnRelatedReports.Add(item);
                            }
                        }
                    }

                }
            }
            else
            {
                returnedUnRelatedReports = Reports;
            }
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedReports = returnedRelatedReports, UnRelatedReports = returnedUnRelatedReports });
            }
          
        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteGroupRelation operation)
        {
            var result = operation.Execute().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }
        [Route("DeleteMultiple")]
        [HttpPost]
        public IApiResult DeleteMultiple(DeleteGroupRelations operation)
        {
            var result = operation.Execute().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }
    }
}