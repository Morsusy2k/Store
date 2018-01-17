using System.Web;
using System.Web.Mvc;
using Membership = Store.PresentationLayer.WebApplication.Security.CustomMembershipProvider;


namespace Store.PresentationLayer.WebApplication.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                if (Membership.IsInRole(new[] { role }))
                {
                    authorize = true;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary {
                    {"action","Login" },{"controller","Account"},{"returnUrl",filterContext.HttpContext.Request.Url.AbsolutePath }
                });
        }
    }
}