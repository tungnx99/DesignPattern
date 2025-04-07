namespace DesignPattern.Controllers.BehavioralPatterns.ChainOfResponsibility
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class HRHiringManagerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Query.TryGetValue("lv", out var lvValue) && int.TryParse(lvValue, out var lv))
            {
                if (lv <= 4)
                {
                    context.Result = new BadRequestObjectResult("HRHiringManager Not Approve");
                }
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            if (
                context.HttpContext.Request.Query.TryGetValue("lv", out var lvValue) && int.TryParse(lvValue, out var lv) &&
                result is ObjectResult json)
            {
                if (lv > 4)
                {
                    json.Value += "\nHRHiringManager Review OK";
                }
            }
        }
    }
}
