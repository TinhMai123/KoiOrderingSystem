using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Service.IService;
using System.Text.RegularExpressions;

namespace KoiOrderingSystem_Web.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserService _service;

        public EditModel(IUserService service)
        {
            _service = service;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _service.ReadById(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (User == null)
            {
                ModelState.AddModelError("User", "User data is required.");
            }

            if (string.IsNullOrEmpty(User.FullName))
            {
                ModelState.AddModelError("User.FullName", "Full name is required.");
            }

            if (string.IsNullOrEmpty(User.Email))
            {
                ModelState.AddModelError("User.Email", "Email is required.");
            }

            if (string.IsNullOrEmpty(User.PhoneNumber))
            {
                ModelState.AddModelError("User.PhoneNumber", "Phone number is required.");
            }

            if (string.IsNullOrEmpty(User.Password))
            {
                ModelState.AddModelError("User.Password", "Password is required.");
            }
            var UserList = await _service.ReadAlls();

            if (UserList.Any(c=>c.Email == User.Email && c.Email != User.Email))
            {
                ModelState.AddModelError("User.Email", $"The email {User.Email} is already taken.");
            }
            if (string.IsNullOrEmpty(User.PhoneNumber))
            {
                ModelState.AddModelError("User.PhoneNumber", "Phone Number is required.");
            }
            else if (!Regex.IsMatch(User.PhoneNumber, @"^(\+|0)?[1-9]\d{7,13}$"))
            {
                ModelState.AddModelError("User.PhoneNumber", "Invalid phone number format.");
            }
            if (UserList.Any(c=>c.PhoneNumber == User.PhoneNumber && c.PhoneNumber != User.PhoneNumber))
            {
                ModelState.AddModelError("User.PhoneNumber", $"The phone number {User.PhoneNumber} is already in use.");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _service.UpdateAsync(User);
            }
            catch (Exception ex)
            {
                if (await UserExists(User.Id) == true)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> UserExists(int id)
        {
            return (await _service.ReadById(id)) != null;
        }
    }
}
