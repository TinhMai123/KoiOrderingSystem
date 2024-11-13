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
          if (!ModelState.IsValid || _service.ReadAlls() == null || User == null)
            {
                return Page();
            }

            await _service.AddAsync(User);

            return RedirectToPage("./Index");
        }
    }
}
