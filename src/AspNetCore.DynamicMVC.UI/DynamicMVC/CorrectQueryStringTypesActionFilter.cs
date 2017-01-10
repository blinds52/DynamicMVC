using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC
{
    public class CorrectQueryStringTypesActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var dynamicController = (DynamicControllerBase) filterContext.Controller;
            dynamicController.CorrectQueryStringTypes();
        }
    }
}