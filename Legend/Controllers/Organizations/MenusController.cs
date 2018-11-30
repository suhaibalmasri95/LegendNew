using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Areas;
using Domain.Operations.Organization.MenuDetails;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionsHandling]
    public class MenusController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateMenu operation)
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
        public IApiResult Update(UpdateMenu operation)
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
        public IActionResult Load(long? ID , long? Type, long? SubMenuID , long? LanguageID )
        {
            GetMenus operation = new GetMenus();
            operation.ID = ID;
            operation.SubMenuID = SubMenuID;
            operation.Type = Type;

            if (LanguageID.HasValue)
                operation.LangID = LanguageID;
            else
                operation.LangID = 1;




            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<Menu>)result);
             
            }
        }

        [Route("LoadParent")]
        [HttpGet]
        public IActionResult LoadParent(long? ID, long? Type, long? SubMenuID, long? LanguageID)
        {

            if (SubMenuID.HasValue)
            {

           
            //First load the Type
            GetMenus operation = new GetMenus();
            // the direct parent of menu
            GetMenus FirstParent = new GetMenus();
            // the second parent of the related menu
            GetMenus SecondParent = new GetMenus();
            // the thid parent of the related menu
            GetMenus ThirdParent = new GetMenus();
           // the fourth parent of the related menu
            GetMenus FourthParent = new GetMenus();
                operation.ID = ID;
            operation.Type = Type;
            if (LanguageID.HasValue)
            {
                operation.LangID = LanguageID;
                FirstParent.LangID = LanguageID;
                SecondParent.LangID = LanguageID;
                ThirdParent.LangID = LanguageID;
                    FourthParent.LangID = LanguageID;
                }
              
            else
            {
                operation.LangID = 1;
                FirstParent.LangID = 1;
                SecondParent.LangID = 1;
                ThirdParent.LangID = 1;
                    FourthParent.LangID = 1;
                }

            var result = operation.QueryAsync().Result;
            var Menus = (List<Menu>)result;

            List<Menu> MenusToReturn = new List<Menu>();
            FirstParent.ID = SubMenuID;
        // Get the first parent of menu
           var FirstMenu = ((List<Menu>)FirstParent.QueryAsync().Result).FirstOrDefault();

            // Get the second Parent of parent of menu
            SecondParent.ID = FirstMenu.SubMenuID;
           var secondMenu = ((List<Menu>)SecondParent.QueryAsync().Result).FirstOrDefault();
            if(secondMenu != null)
            {
                // Get the third Parent
                ThirdParent.ID = secondMenu.SubMenuID;
                var ThirdMenu = ((List<Menu>)ThirdParent.QueryAsync().Result).FirstOrDefault();
                if(ThirdMenu!=null)
                {
                        // Get fourth Parent
                        FourthParent.ID = ThirdParent.SubMenuID;
                        var FourthMenu = ((List<Menu>)FourthParent.QueryAsync().Result).FirstOrDefault();

                        if(FourthParent!=null)
                        {
                            foreach (var item in Menus)
                            {
                                if (item.SubMenuID == ThirdMenu.ID && ThirdMenu.SubMenuID == secondMenu.ID && secondMenu.SubMenuID == FirstMenu.ID)
                                {
                                    item.SystemMenuID = FirstMenu.SubMenuID;
                                    item.SystemMenuName = FirstMenu.Name;

                                    item.ModuleMenuID = secondMenu.ID;
                                    item.ModuleMenuName = secondMenu.Name;
                                    item.SubModuleMenuID = ThirdMenu.ID;
                                    item.SubModuleMenuName = ThirdMenu.Name;
                                    MenusToReturn.Add(item);

                                }

                            }
                        }
                        else { 
                        foreach (var item in Menus)
                        {
                            if (item.SubMenuID == secondMenu.ID && secondMenu.SubMenuID == FirstMenu.ID)
                            {
                                item.SystemMenuID = FirstMenu.ID;
                                item.SystemMenuName = FirstMenu.Name;

                                item.ModuleMenuID = secondMenu.ID;
                            item.ModuleMenuName = secondMenu.Name;
                            item.SubModuleMenuID = FirstMenu.ID;
                            item.SubModuleMenuName = FirstMenu.Name;
                            MenusToReturn.Add(item);

                            }

                        }
                        }


                    }
                else
                {
                  
                    foreach (var item in Menus)
                    {
                        if (item.SubMenuID == FirstMenu.ID  )
                        {
                            item.SystemMenuID = FirstMenu.ID;
                            item.SystemMenuName = FirstMenu.Name;

                            item.ModuleMenuID = secondMenu.ID;
                            item.ModuleMenuName = secondMenu.Name;
                            MenusToReturn.Add(item);

                        }

                    }
                }

            }
            else
            {
          
                foreach (var item in Menus)
                {
                    if (item.SubMenuID == FirstMenu.ID )
                    {
                        item.SystemMenuID = FirstMenu.ID;
                        item.SystemMenuName = FirstMenu.Name;

                        MenusToReturn.Add(item);

                    }

                }
            }
         

            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(MenusToReturn);

                }
            }
            else
            {
                List<Menu> MenusToReturn = new List<Menu>();
                //First load the Type
                GetMenus operation = new GetMenus();
                // the direct parent of menu
                GetMenus FirstChild = new GetMenus();
                // the second parent of the related menu
                GetMenus SecondChild = new GetMenus();
                // the thid parent of the related menu
                GetMenus ThirdChild = new GetMenus();
                // the fourth parent of the related menu
                GetMenus FourthChild = new GetMenus();
                operation.Type = 1;
                var result = operation.QueryAsync().Result;
                var Menus = (List<Menu>)result;
                foreach (var item in Menus)
                {
                    FirstChild.Type = 2;
                    var firstChild = (List<Menu>)FirstChild.QueryAsync().Result;
                    if (firstChild.Count > 0)
                    { 
                    foreach (var child in firstChild)
                    {
                        item.ModuleMenuID = child.ID;
                        item.ModuleMenuName = child.Name;
                        SecondChild.Type = 3;
                        var secondChild = (List<Menu>)SecondChild.QueryAsync().Result;
                        if(secondChild.Count > 0)
                        {
                        foreach (var child2 in secondChild)
                        {
                            item.SubModuleMenuID = child2.ID;
                            item.SubModuleMenuName = child2.Name;
                            ThirdChild.Type = 4;
                            var thirdChild = (List<Menu>)ThirdChild.QueryAsync().Result;
                            if(thirdChild.Count >0)
                            { 
                            foreach (var child3 in thirdChild)
                            {
                                item.PageMenuID = child3.ID;
                                item.PageMenuName = child3.Name;
                                FourthChild.Type = 5;
                                var fourthChild = (List<Menu>)FourthChild.QueryAsync().Result;
                                if(fourthChild.Count>0)
                                { 
                                foreach (var child4 in fourthChild)
                                {
                                    item.ActionMenuID = child4.ID;
                                    item.ActionMenuName = child4.Name;
                                    MenusToReturn.Add(item);

                                }
                                }
                                else
                                {
                                    MenusToReturn.Add(item);
                                }
                            }
                            }
                            else
                            {
                                MenusToReturn.Add(item);
                            }
                            }
                        }
                        else
                        {
                            MenusToReturn.Add(item);
                        }
                        }
                    }
                    else
                    {
                        MenusToReturn.Add(item);
                    }
                }
                return Ok(MenusToReturn);
            }

        }


        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteMenu operation)
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
        public IApiResult DeleteMultiple(DeleteMenus operation)
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
