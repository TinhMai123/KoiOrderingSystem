using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class DeleteModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public DeleteModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
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

            var farmkoitype = await _context.FarmKoiTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (farmkoitype == null)
            {
                return NotFound();
            }
            else 
            {
                FarmKoiType = farmkoitype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FarmKoiTypes == null)
            {
                return NotFound();
            }
            var farmkoitype = await _context.FarmKoiTypes.FindAsync(id);

            if (farmkoitype != null)
            {
                FarmKoiType = farmkoitype;
                _context.FarmKoiTypes.Remove(FarmKoiType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
