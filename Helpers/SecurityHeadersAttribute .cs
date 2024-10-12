using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace Hrm.Helpers
{
    public class SecurityHeadersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;

            response.Headers[HeaderNames.XContentTypeOptions] = "nosniff"; 
            response.Headers[HeaderNames.XXSSProtection] = "1; mode=block"; 
            response.Headers[HeaderNames.XFrameOptions] = "DENY";
            response.Headers["Referrer-Policy"] = "no-referrer";
            response.Headers[HeaderNames.ContentSecurityPolicy] = "default-src 'self';";
            response.Headers["PermissionsPolicy"] = "geolocation=(self), camera=()";
            response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains";
            response.Headers["X-Download-Options"] = "noopen";
            response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
            response.Headers["Expires"] = "0";

            base.OnActionExecuted(context);
        }
    }

}