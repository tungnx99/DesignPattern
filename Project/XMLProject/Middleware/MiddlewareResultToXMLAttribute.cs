namespace XMLProject.Middleware
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class MiddlewareResultToXMLAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.ContentType = "text/xml";

            base.OnActionExecuting(context);
        }
    }
}
