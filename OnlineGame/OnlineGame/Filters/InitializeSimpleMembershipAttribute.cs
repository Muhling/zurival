using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using OnlineGame.Models;
using Models;
using Models.Repositories;
using System.Web;

namespace OnlineGame.Filters
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase filterContext)
        {
            if (filterContext.Session["CurrentUser"] == null)
                return false;
            else
            {
                var user = (User)filterContext.Session["CurrentUser"];

                if (new AccountRepository().UserIsValid(user.Email, user.Password))
                    return true;
                else
                {
                    filterContext.Session["CurrentUser"] = null;
                    return false;
                }
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Login");
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
