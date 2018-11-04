using Microsoft.AspNetCore.Mvc.Filters;
using Oracle.ManagedDataAccess.Client;
using System;
namespace Infrastructure.Attributes
{
    public class ExceptionsHandling : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var currentException = context.Exception;
            if (currentException is OracleException)
            {
                // Do the Log 
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
