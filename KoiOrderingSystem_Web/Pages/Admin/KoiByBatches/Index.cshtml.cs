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
    public class IndexModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public IndexModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IList<KoiByBatch> KoiByBatch { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.KoiByBatches != null)
            {
                KoiByBatch = await _context.KoiByBatches
                .Include(k => k.KoiType).ToListAsync();
            }
        }
    }
}
