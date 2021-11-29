using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.CustomException;
using ZarvanOrder.Helpers;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.Users;

namespace ZarvanOrder.Filters
{
    public class CustomAuthorizationFilter : ActionFilterAttribute, IAllowAnonymous
    {

        public CustomAuthorizationFilter()
        {
        }
        private string _role = "";
        public CustomAuthorizationFilter(string Role)
        {
            _role = Role;
        }
        public string AuthenticationSchemes { get; set; }
        public string Policy { get; set; }
        public string Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IWebHostEnvironment env = context.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
            if (env.EnvironmentName == "Development")
            {
                return;
            }
            ErrorResponse Err = null;
            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
                                .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));
            if (!hasAllowAnonymous)
            {
                var Result = new JsonResult(new ErrorResponse());
                Result.ContentType = "application/json";
                if (context.HttpContext.Request.Headers["Authorization"].ToString().StartsWith("Bearer") == false)
                {
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    Err = new ErrorResponse()
                    {
                        Description =Model.Messages.General.Unauthorized,
                        Code = context.HttpContext.Response.StatusCode
                    };

                    throw new MyException(context.HttpContext.Response.StatusCode, Err.Description);
                }
                var token = context.HttpContext.Request.Headers["Authorization"].ToString();
                if (token == "")
                {
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    Err = new ErrorResponse()
                    {
                        Description = Model.Messages.General.Unauthorized,
                        Code = context.HttpContext.Response.StatusCode
                    };

                    Result.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    throw new MyException(context.HttpContext.Response.StatusCode, Err.Description);
                }
                token = token.Substring(6, token.Length - 6).Trim();



                var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                var User = JWTTokenManager.ValidateToken(token, userService.GetsAsync(new GetUsersRequest()).Result);
                if (User == null)
                {
                    userService.SignoutAsync();
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    Err = new ErrorResponse()
                    {
                        Description = Model.Messages.General.Unauthorized,
                        Code = context.HttpContext.Response.StatusCode
                    };
                    throw new MyException(context.HttpContext.Response.StatusCode, Err.Description);
                }
                bool IsAdmin = true;
                //IsAdmin = true ? (from u in dbContext.Users
                //                  join ur in dbContext.UserRoles
                //                  on u.Id equals ur.UserId
                //                  join r in dbContext.Roles
                //                  on ur.RoleId equals r.Id
                //                  where u.UserName == User && r.Name == "Administrator"
                //                  select 1).Count() != 0 : false;
                //    if (IsAdmin == false)
                //    {
                //        var Route = context.RouteData;
                //        string CurrentController = Route.Values["Controller"].ToString();
                //        string CurrentAction = Route.Values["Action"].ToString();
                //        string Url = string.Format("/api/{0}/{1}", CurrentController, CurrentAction);
                //        var p = dbContext.RolePermissions.FirstOrDefault(x => x.Url == Url);
                //        if (p == null)
                //        {
                //            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                //            Err = new ErrorResponse()
                //            {
                //                Description = Model.Messages.General.UnauthorizedURL,
                //                Code = context.HttpContext.Response.StatusCode
                //            };
                //            Result.Value = Err;
                //            Result.StatusCode = context.HttpContext.Response.StatusCode;
                //            context.Result = Result;
                //            return;
                //        }
                //        p.Id = 0;
                //        if ((JWTTokenManager.ValidatePermissionToken(p.Token) == null) ||
                //            (!JWTTokenManager.ValidatePermissionToken(p.Token).Equals(p.Url))
                //            )
                //        {
                //            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                //            Err = new ErrorResponse()
                //            {
                //                Description =Model.Messages.General.UnauthorizedURL,
                //                Code = context.HttpContext.Response.StatusCode
                //            };
                //            context.Result = new JsonResult(Err);
                //            return;
                //        }
                //    }
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            return base.OnResultExecutionAsync(context, next);
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }

    }
}
