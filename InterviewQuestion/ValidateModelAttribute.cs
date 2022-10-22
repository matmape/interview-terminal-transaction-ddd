using InterviewQuestion.Domain.Shared;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestion.API
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(c => c.Errors.Select(d => d.ErrorMessage)).ToList();
                context.Result = new BadRequestObjectResult(Response<object>.ValidationError(errors));
            }
        }
    }
}
