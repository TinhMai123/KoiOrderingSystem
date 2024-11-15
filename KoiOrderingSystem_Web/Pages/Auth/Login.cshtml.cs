using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiOrderingSystem_Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userService.GetUserByEmail(Email);

            if (user != null && Password == user.Password)
            {
                // Store user role in session
                HttpContext.Session.SetString("User",JsonUtils.ToJson(user));

                switch (user.Role)
                {
                    case "Admin":
                        return Redirect("Admin/Dashboard");
                    default:
                        return Redirect("Index");
                }
            }
            else
            {
                Message = "Invalid username or password";
                return Page();
            }
        }

    }
}
