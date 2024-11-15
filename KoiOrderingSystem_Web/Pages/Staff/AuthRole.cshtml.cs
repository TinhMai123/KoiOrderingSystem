using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Staff
{
    public class AuthRoleModel : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            // Check if the user session exists
            var user = JsonUtils.FromJson<User>(HttpContext.Session.GetString("User"));
            if (user == null)
            {
                // If no session, redirect to login
                context.Result = Redirect("/Login");
            }
            if (user.Role != "Staff")
            {
                context.Result = Redirect("/Staff/Sales/Index");
            }
            ViewData["User"] = user;
            base.OnPageHandlerExecuting(context);
        }
    }
}
