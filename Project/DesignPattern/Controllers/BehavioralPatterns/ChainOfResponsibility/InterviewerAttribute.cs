namespace DesignPattern.Controllers.BehavioralPatterns.ChainOfResponsibility
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class InterviewerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Query.TryGetValue("lv", out var lvValue) && int.TryParse(lvValue, out var lv))
            {
                if (lv <= 2)
                {
                    context.Result = new BadRequestObjectResult("Interviewer Not Approve");
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
                if (lv > 2)
                {
                    json.Value += "\nInterviewer Review OK";
                }
            }
        }
    }
}
