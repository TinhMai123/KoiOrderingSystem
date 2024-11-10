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

namespace KoiOrderingSystem_Web.Pages.Admin.KoiByBatches
{
    public class EditModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public EditModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
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

            var koibybatch =  await _context.KoiByBatches.FirstOrDefaultAsync(m => m.Id == id);
            if (koibybatch == null)
            {
                return NotFound();
            }
            KoiByBatch = koibybatch;
           ViewData["KoiTypeId"] = new SelectList(_context.KoiTypes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KoiByBatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiByBatchExists(KoiByBatch.Id))
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

        private bool KoiByBatchExists(int id)
        {
          return (_context.KoiByBatches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
