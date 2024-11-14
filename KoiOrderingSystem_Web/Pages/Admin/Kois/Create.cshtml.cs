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

namespace KoiOrderingSystem_Web.Pages.Admin.Kois
{
    public class CreateModel : PageModel
    {
        private readonly IKoiService _service;

        public CreateModel(IKoiService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Koi Koi { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Koi == null)
            {
                ModelState.AddModelError(string.Empty, "Koi cannot be null.");
                return Page();
            }

            if (Koi.Weight <= 0)
            {
                ModelState.AddModelError("Koi.Weight", "A Koi cannot have a weight of 0 or smaller.");
            }
            if (Koi.BirthDate > DateTime.UtcNow || Koi.BirthDate.Year - 300 < 0)
            {
                ModelState.AddModelError("Koi.BirthDate", "A Koi Fish cannot have a Birth Date like that.");
            }

            if (Koi.DateAdded > DateTime.UtcNow || Koi.DateAdded.Year - 300 < 0)
            {
                ModelState.AddModelError("Koi.DateAdded", "A Koi Fish cannot have a Date like that.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddAsync(Koi);

            return RedirectToPage("./Index");
        }

    }
}
