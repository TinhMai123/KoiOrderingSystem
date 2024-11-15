using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages
{
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            var userString = HttpContext.Session.GetString("User") ?? "";
            if (string.IsNullOrEmpty(userString) )
            {
                return Redirect("/Login");
            }
            var user = JsonUtils.FromJson<User>(userString);
            if (user == null || user.Role != "Admin")
            {
                return Redirect("/Login");
            }
            return Page();
        }
    }
}
