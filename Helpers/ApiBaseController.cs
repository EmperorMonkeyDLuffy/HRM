using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hrm.Helpers
{
    [BasicAuthentication]
    [SecurityHeaders]
    public class ApiBaseController : Controller
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext _context, ActionExecutionDelegate next)
        {

            await base.OnActionExecutionAsync(_context, next);
        }







        public async Task<IActionResult> ResponseWrapperAsync<T>(Func<Task<T>> func)
        {
            try
            {
                T result = await func();
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }




        private IActionResult HandleError(Exception ex)
        {
            switch (ex)
            {
                case ArgumentNullException _:
                    return new BadRequestObjectResult(new { message = "A required parameter was null." });

                case ArgumentException _:
                    return new BadRequestObjectResult(new { message = "Invalid argument provided." });

                case KeyNotFoundException _:
                    return new NotFoundObjectResult(new { message = "The requested resource was not found." });

                case UnauthorizedAccessException _:
                    return new UnauthorizedObjectResult(new { message = "You do not have permission to perform this action." });

                case InvalidOperationException _:
                    return new BadRequestObjectResult(new { message = "The request could not be processed due to an invalid operation." });

                case TimeoutException _:
                    return new StatusCodeResult(504);

                default:
                    return new BadRequestObjectResult(ex.Message);

            }
        }

    }
}
