using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace KoiOrderingSystem_Web.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private IUserService _service;

        public RegisterModel(IUserService service)
        {
            _service = service;
        }

        [BindProperty]
        public User User { get; set; } = default!;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync() 
        {
            var list = await _service.ReadAlls();
            if (User == null)
            {
                ModelState.AddModelError("User", "User data is required.");
            }

            if (string.IsNullOrEmpty(User.FullName))
            {
                ModelState.AddModelError("User.FullName", "Full Name is required.");
            }

            if (string.IsNullOrEmpty(User.Email))
            {
                ModelState.AddModelError("User.Email", "Email is required.");
            }
            else if (!Regex.IsMatch(User.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ModelState.AddModelError("User.Email", "Invalid email format.");
            }

            if (string.IsNullOrEmpty(User.PhoneNumber))
            {
                ModelState.AddModelError("User.PhoneNumber", "Phone Number is required.");
            }
            else if (!Regex.IsMatch(User.PhoneNumber, @"^(\+|0)?[1-9]\d{7,13}$"))
            {
                ModelState.AddModelError("User.PhoneNumber", "Invalid phone number format.");
            }
            if (string.IsNullOrEmpty(User.Password))
            {
                ModelState.AddModelError("User.Password", "Password is required.");
            }
            else if (User.Password.Length < 6)
            {
                ModelState.AddModelError("User.Password", "Password must be at least 6 characters long.");
            }

            if (string.IsNullOrEmpty(User.Address))
            {
                ModelState.AddModelError("User.Address", "Address is required.");
            }
            if (list.Any(c => c.Email == User.Email))
            {
                ModelState.AddModelError("User.Email", $"The email {User.Email} is already taken.");
            }
            if (list.Any(c => c.PhoneNumber == User.PhoneNumber))
            {
                ModelState.AddModelError("User.PhoneNumber", $"The phone number {User.PhoneNumber} is already in use.");
            }
            if (!ModelState.IsValid || await _service.ReadAlls() == null)
            {
                return Page();
            }
            User.Role = "Customer";
            await _service.AddAsync(User);
            HttpContext.Session.SetString("User", JsonUtils.ToJson(User));
            return Redirect("/");
        }
    }
}
