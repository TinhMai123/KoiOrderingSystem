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

        public CreateModel(IFarmService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Farm Farm { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || await _service.ReadAlls() == null || Farm == null)
            {
                return Page();
            }

            await _service.AddAsync(Farm);

            return RedirectToPage("./Index");
        }
    }
}
