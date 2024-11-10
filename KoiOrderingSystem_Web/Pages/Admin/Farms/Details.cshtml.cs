using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Admin.Farms
{
    public class DetailsModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public DetailsModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

      public Farm Farm { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Farms == null)
            {
                return NotFound();
            }

            var farm = await _context.Farms.FirstOrDefaultAsync(m => m.Id == id);
            if (farm == null)
            {
                return NotFound();
            }
            else 
            {
                Farm = farm;
            }
            return Page();
        }
    }
}
