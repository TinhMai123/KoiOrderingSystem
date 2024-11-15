using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer
{
    public class _layoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            var user = HttpContext.Session.GetString("User");
            if (user == null)
            {
                return Redirect("/Login");
            }
            return Page();
        }
    }
}
