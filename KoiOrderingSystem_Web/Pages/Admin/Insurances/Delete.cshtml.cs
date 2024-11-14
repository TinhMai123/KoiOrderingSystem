using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Admin.Insurances
{
    public class DeleteModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public DeleteModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Insurance Insurance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Insurances == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurances.FirstOrDefaultAsync(m => m.Id == id);

            if (insurance == null)
            {
                return NotFound();
            }
            else 
            {
                Insurance = insurance;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Insurances == null)
            {
                return NotFound();
            }
            var insurance = await _context.Insurances.FindAsync(id);

            if (insurance != null)
            {
                Insurance = insurance;
                _context.Insurances.Remove(Insurance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
