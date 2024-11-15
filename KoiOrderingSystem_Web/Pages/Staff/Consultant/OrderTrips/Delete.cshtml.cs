using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Staff.Consultant.OrderTrips
{
    public class DeleteModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public DeleteModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OrderTrip OrderTrip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderTrips == null)
            {
                return NotFound();
            }

            var ordertrip = await _context.OrderTrips.FirstOrDefaultAsync(m => m.Id == id);

            if (ordertrip == null)
            {
                return NotFound();
            }
            else 
            {
                OrderTrip = ordertrip;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OrderTrips == null)
            {
                return NotFound();
            }
            var ordertrip = await _context.OrderTrips.FindAsync(id);

            if (ordertrip != null)
            {
                OrderTrip = ordertrip;
                _context.OrderTrips.Remove(OrderTrip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
