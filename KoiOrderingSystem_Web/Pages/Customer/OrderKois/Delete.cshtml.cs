using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Customer.OrderKois
{
    public class DeleteModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public DeleteModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OrderKoi OrderKoi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderKois == null)
            {
                return NotFound();
            }

            var orderkoi = await _context.OrderKois.FirstOrDefaultAsync(m => m.Id == id);

            if (orderkoi == null)
            {
                return NotFound();
            }
            else 
            {
                OrderKoi = orderkoi;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OrderKois == null)
            {
                return NotFound();
            }
            var orderkoi = await _context.OrderKois.FindAsync(id);

            if (orderkoi != null)
            {
                OrderKoi = orderkoi;
                _context.OrderKois.Remove(OrderKoi);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
