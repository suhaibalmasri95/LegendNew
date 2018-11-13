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
        public IApiResult Update(UpdateMenu operation)
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

            //First load the Type
            GetMenus operation = new GetMenus();
            // the direct parent of menu
            GetMenus FirstParent = new GetMenus();
            // the second parent of the related menu
            GetMenus SecondParent = new GetMenus();
            // the thid parent of the related menu
            GetMenus ThirdParent = new GetMenus();
            // the fourth parent of the related menu
        
            operation.ID = ID;
            operation.Type = Type;
            if (LanguageID.HasValue)
            {
                operation.LangID = LanguageID;
                FirstParent.LangID = LanguageID;
                SecondParent.LangID = LanguageID;
                ThirdParent.LangID = LanguageID;
              
           
            }
              
            else
            {
                operation.LangID = 1;
                FirstParent.LangID = 1;
                SecondParent.LangID = 1;
                ThirdParent.LangID = 1;
            
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
                  
                      
                        foreach (var item in Menus)
                        {
                            if (item.SubMenuID == FirstMenu.ID && FirstMenu.SubMenuID == secondMenu.ID && secondMenu.SubMenuID == ThirdMenu.ID)
                            {
                                item.SystemMenuID = ThirdMenu.SubMenuID;
                                item.SystemMenuName = ThirdMenu.Name;

                                item.ModuleMenuID = secondMenu.SubMenuID;
                            item.ModuleMenuName = secondMenu.ModuleMenuName;
                            item.SubMoudleMenuID = FirstMenu.SubMenuID;
                            item.SubMoudleMenuName = FirstMenu.Name;
                            MenusToReturn.Add(item);

                            }

                        }

                    
                }
                else
                {
                  
                    foreach (var item in Menus)
                    {
                        if (item.SubMenuID == FirstMenu.ID && FirstMenu.SubMenuID == secondMenu.ID )
                        {
                            item.SystemMenuID = secondMenu.SubMenuID;
                            item.SystemMenuName = secondMenu.Name;

                            item.ModuleMenuID = FirstMenu.SubMenuID;
                            item.ModuleMenuName = FirstMenu.ModuleMenuName;
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
                        item.SystemMenuID = FirstMenu.SubMenuID;
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


        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteMenu operation)
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
