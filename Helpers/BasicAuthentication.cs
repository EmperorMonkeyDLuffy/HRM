using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;


namespace Hrm.Helpers
{
    public class BasicAuthentication : TypeFilterAttribute
    {

        public BasicAuthentication() : base(typeof(BasicAuthenticationFilter))
        {

        }

        private class BasicAuthenticationFilter : IAsyncAuthorizationFilter
        {

            public BasicAuthenticationFilter()
            {
            }

            public async Task OnAuthorizationAsync(AuthorizationFilterContext _context)
            {

                Microsoft.Extensions.Primitives.StringValues token;
                _context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
                string t = token.ToString().Replace("Bearer ", string.Empty);
                if (t != "28bd6087-6b23-4a6c-971b-490e014c2563")
                {
                    _context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}