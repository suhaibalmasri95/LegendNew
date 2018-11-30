using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Groups;
using Domain.Operations.Organization.UserGroups;
using Domain.Operations.Organization.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateUserGroup operation)
        {
            var result = operation.ExecuteAsync().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }
        [Route("AddUsersToGroup")]
        [HttpPost]
        public IApiResult AddUsersToGroup(AddUsersToGroup operation)
        {
            var result = operation.ExecuteAsync().Result;
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
        public IApiResult Update(UpdateUserGroup operation)
        {
            var result = operation.ExecuteAsync().Result;
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
        public IActionResult Load(Int64? ID,Int64? userID, Int64? langId)
        {

            GetUserGroups operation = new GetUserGroups();
            
               
                if (langId.HasValue)
                    operation.LangID = langId;
                else
                    operation.LangID = 1;
            if (!userID.HasValue)
            {
                operation.ID = ID;
                var results = operation.QueryAsync().Result;
                return Ok((List<UserGroup>)results);
            }
            operation.UserID = userID;
            var result = operation.QueryAsync().Result;
            var userGroups = (List<UserGroup>)result;
            GetGroups groups = new GetGroups();
            groups.LangID = 1;
            if (langId.HasValue)
                groups.LangID = langId;
            else
                groups.LangID = 1;
            var Groups = (List<Group>)groups.QueryAsync().Result;
            List<Group> returnedRelatedGroups = new List<Group>();
            List<Group> returnedUnRelatedGroups = new List<Group>();
            if (userGroups.Count > 0)
            {
          foreach (var group in Groups)
                {
                    foreach (var item in userGroups)
                    {
                        if (group.ID == item.RefrenceID)
                        {
                            bool alreadyExist = returnedRelatedGroups.Contains(group);
                            bool alreadyExistInSecondList = returnedUnRelatedGroups.Contains(group);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {
                                group.UserRelationID = item.ID;
                                returnedRelatedGroups.Add(group);
                            }
                            else
                            {
                                group.UserRelationID = item.ID;
                                returnedRelatedGroups.Add(group);
                                returnedUnRelatedGroups.Remove(group);
                            }
                        }
                        else
                        {
                            bool alreadyExist = returnedUnRelatedGroups.Contains(group);
                            bool alreadyExistInFirstList = returnedRelatedGroups.Contains(group);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {
                                group.UserRelationID = item.ID;
                                returnedUnRelatedGroups.Add(group);
                            }
                        }
                    }

            }
            }
            else
            {
                returnedUnRelatedGroups = Groups;
            }
           

            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedGroups= returnedRelatedGroups, UnRelatedGroups= returnedUnRelatedGroups });
            }

        }
        [Route("LoadUserGroup")]
        [HttpGet]
        public IActionResult LoadUserGroup(Int64? ID, Int64? groupID, Int64? langId)
        {

            GetUserGroups operation = new GetUserGroups();
            GetUsers users = new GetUsers();

            List<User> returnedRelatedGroups = new List<User>();
            List<User> returnedUnRelatedGroups = new List<User>();
            if (langId.HasValue)
            {
                operation.LangID = langId;
                users.LangID = langId;
            }
            else
            {
                operation.LangID = 1;
                users.LangID = 1;
            }
            var result =operation.QueryAsync().Result;
            var usersList = (List<User>)users.QueryAsync().Result;
            var userIDsInGroup = (List<UserGroup>)result;
            userIDsInGroup = userIDsInGroup.Where(g => g.RefrenceID == groupID).ToList();
            if (userIDsInGroup.Count > 0)
            {
                foreach (var item in userIDsInGroup)
                {
                    foreach (var user in usersList)
                    {
                        if (user.ID == item.UserID)
                        {
                            bool alreadyExist = returnedRelatedGroups.Contains(user);
                            bool alreadyExistInSecondList = returnedUnRelatedGroups.Contains(user);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {
                                user.UserRelationID = item.ID;
                                returnedRelatedGroups.Add(user);
                            }
                            else
                            {
                                user.UserRelationID = item.ID;
                                returnedRelatedGroups.Add(user);
                                returnedUnRelatedGroups.Remove(user);
                            }
                        }
                        else
                        {
                            bool alreadyExist = returnedUnRelatedGroups.Contains(user);
                            bool alreadyExistInFirstList = returnedRelatedGroups.Contains(user);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {
                                user.UserRelationID = item.ID;
                                returnedUnRelatedGroups.Add(user);
                            }
                        }

                    }

                }
            }
            else
            {
                returnedUnRelatedGroups = usersList;
            }


            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedGroups = returnedRelatedGroups, UnRelatedGroups = returnedUnRelatedGroups });
            }

        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteUserGroup operation)
        {
         
            var result = operation.ExecuteAsync().Result;
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
        public IApiResult DeleteMultiple(DeleteUserGroups operation)
        {
            var result = operation.ExecuteAsync().Result;
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