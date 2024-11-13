using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Service.IService;
using System.Text.RegularExpressions;

namespace KoiOrderingSystem_Web.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _service;
        private readonly IFarmService _farmService;

        public CreateModel(IUserService service, IFarmService farm)
        {
            _service = service;
            _farmService = farm;
        }

        public async Task<IActionResult> OnGet()
        {
            var farms = await _farmService.ReadAlls();
            ViewData["FarmId"] = new SelectList(farms, "Id", "FarmName");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
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
            else if (!Regex.IsMatch(User.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
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

            if (string.IsNullOrEmpty(User.Role))
            {
                ModelState.AddModelError("User.Role", "Role is required.");
            }

            if (User.FarmId == 0)
            {
                ModelState.AddModelError("User.FarmId", "Farm must be selected.");
            }
            var UserList = await _service.ReadAlls();

            if (UserList.Any(c => c.Email == User.Email))
            {
                ModelState.AddModelError("User.Email", $"The email {User.Email} is already taken.");
            }
            if (UserList.Any(c => c.PhoneNumber == User.PhoneNumber))
            {
                ModelState.AddModelError("User.PhoneNumber", $"The phone number {User.PhoneNumber} is already in use.");
            }
            // Check if email already exists in the system
            if (!ModelState.IsValid || await _service.ReadAlls() == null)
            {
                return Page();
            }

            await _service.AddAsync(User);

            return RedirectToPage("./Index");
        }

    }
}
