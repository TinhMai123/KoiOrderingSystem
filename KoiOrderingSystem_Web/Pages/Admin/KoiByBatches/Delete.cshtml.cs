using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Admin.KoiByBatches
{
    public class DeleteModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public DeleteModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public KoiByBatch KoiByBatch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.KoiByBatches == null)
            {
                return NotFound();
            }

            var koibybatch = await _context.KoiByBatches.FirstOrDefaultAsync(m => m.Id == id);

            if (koibybatch == null)
            {
                return NotFound();
            }
            else 
            {
                KoiByBatch = koibybatch;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.KoiByBatches == null)
            {
                return NotFound();
            }
            var koibybatch = await _context.KoiByBatches.FindAsync(id);

            if (koibybatch != null)
            {
                KoiByBatch = koibybatch;
                _context.KoiByBatches.Remove(KoiByBatch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
