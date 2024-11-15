using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class CreateModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public CreateModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Description");
        ViewData["KoiTypeId"] = new SelectList(_context.KoiTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public FarmKoiType FarmKoiType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FarmKoiTypes == null || FarmKoiType == null)
            {
                return Page();
            }

            _context.FarmKoiTypes.Add(FarmKoiType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
