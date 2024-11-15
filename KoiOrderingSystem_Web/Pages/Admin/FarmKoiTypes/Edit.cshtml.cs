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

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class EditModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public EditModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FarmKoiType FarmKoiType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FarmKoiTypes == null)
            {
                return NotFound();
            }

            var farmkoitype =  await _context.FarmKoiTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (farmkoitype == null)
            {
                return NotFound();
            }
            FarmKoiType = farmkoitype;
           ViewData["FarmId"] = new SelectList(_context.Farms, "Id", "Description");
           ViewData["KoiTypeId"] = new SelectList(_context.KoiTypes, "Id", "Name");
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

            _context.Attach(FarmKoiType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmKoiTypeExists(FarmKoiType.Id))
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

        private bool FarmKoiTypeExists(int id)
        {
          return (_context.FarmKoiTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
