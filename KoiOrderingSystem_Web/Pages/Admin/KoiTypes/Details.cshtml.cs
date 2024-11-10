using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Admin.KoiTypes
{
    public class DetailsModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public DetailsModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

      public KoiType KoiType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.KoiTypes == null)
            {
                return NotFound();
            }

            var koitype = await _context.KoiTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (koitype == null)
            {
                return NotFound();
            }
            else 
            {
                KoiType = koitype;
            }
            return Page();
        }
    }
}
