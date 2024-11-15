using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {

            HttpContext.Session.Remove("User");

            return Redirect("/");
        }
    }
}