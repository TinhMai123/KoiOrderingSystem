using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer
{
    public class AuthPageModel : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            // Check if the user session exists
            var user = HttpContext.Session.GetString("User");
            if (user == null)
            {
                // If no session, redirect to login
                context.Result = Redirect("/Login");
            }
            base.OnPageHandlerExecuting(context);
        }
    }
}
