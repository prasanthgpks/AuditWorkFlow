using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuditWorkFlow.Api.Filters
{
    public class ApiAuthorizeAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Host.Value == "localhost")
            {
                // It was a local request => authorize the guy
                return;
            }

            var authorizeAttribute = new AuthorizeAttribute();
            authorizeAttribute.OnAuthorization(context);
        }
        
    }
}
