using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiOrderingSystem_Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            const string hardcodedUsername = "admin@gmail.com";
            const string hardcodedPassword = "123456";

            if (Email == hardcodedUsername && Password == hardcodedPassword)
            {
                return RedirectToPage("Index");
            }
            else
            {
                Message = "Invalid username or password";
                return Page();
            }
        }
    }
}
