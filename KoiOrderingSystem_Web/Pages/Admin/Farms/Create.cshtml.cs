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

namespace KoiOrderingSystem_Web.Pages.Admin.Farms
{
    public class CreateModel : PageModel
    {
        private readonly IFarmService _service;
        private readonly IUserService _userService;

        public CreateModel(IFarmService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var users = await _userService.ReadAlls();
            ViewData["ManagerId"] = new SelectList(users.Where(m => m.Role == "Manager"), "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Farm Farm { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public class CreateModel : PageModel
        {
            private readonly IFarmService _service;

            public CreateModel(IFarmService service)
            {
                _service = service;
            }

            [BindProperty]
            public Farm Farm { get; set; }

            public async Task<IActionResult> OnPostAsync()
            {
                // Manual validation
                if (string.IsNullOrEmpty(Farm.FarmName))
                {
                    ModelState.AddModelError("Farm.FarmName", "Farm name is required.");
                }

                if (string.IsNullOrEmpty(Farm.Location))
                {
                    ModelState.AddModelError("Farm.Location", "Location is required.");
                }

                if (Farm.EstablishedYear < 1500 || Farm.EstablishedYear > DateTime.UtcNow.Year)
                {
                    ModelState.AddModelError("Farm.EstablishedYear", "Established Year must be between 1500 and the current year.");
                }

                if (!ModelState.IsValid)
                {
                    // If validation failed, return to the page with error messages
                    return Page();
                }

                // Proceed to service layer if validation passed
                await _service.AddAsync(Farm);

                return RedirectToPage("./Index");
            }
        }


    }
}
