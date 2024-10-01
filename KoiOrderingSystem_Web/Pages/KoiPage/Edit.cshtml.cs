using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;

namespace KoiOrderingSystem_Web.Pages.KoiPage
{
    public class EditModel : PageModel
    {
        private readonly KoiOrderingSystem_DAO.KoiOrderingSystemInJapanContext _context;

        public EditModel(KoiOrderingSystem_DAO.KoiOrderingSystemInJapanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal =  await _context.Animals.FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }
            Animal = animal;
           ViewData["AnimalVarietyId"] = new SelectList(_context.AnimalVarieties, "AnimalVarietyId", "AnimalVarietyId");
           ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmId");
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

            _context.Attach(Animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(Animal.AnimalId))
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

        private bool AnimalExists(int id)
        {
          return (_context.Animals?.Any(e => e.AnimalId == id)).GetValueOrDefault();
        }
    }
}
