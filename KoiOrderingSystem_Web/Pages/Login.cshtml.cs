using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            // Method to handle GET requests (e.g., when the page is first loaded)
        }

        public IActionResult OnPost()
        {
            // Hardcoded username and password for demo purposes
            const string hardcodedUsername = "admin";
            const string hardcodedPassword = "password";

            if (Username == hardcodedUsername && Password == hardcodedPassword)
            {
                // If login is successful, redirect to the index page (or another page)
                return RedirectToPage("/KoiOrderingSystemPage");
            }
            else
            {
                // Show error message on invalid login
                Message = "Invalid username or password";
                return Page();
            }
        }
    }
}
