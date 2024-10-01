using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;

namespace KoiOrderingSystem_Web.Pages.KoiPage
{
    public class CreateModel : PageModel
    {
        private readonly KoiOrderingSystem_DAO.KoiOrderingSystemInJapanContext _context;

        public CreateModel(KoiOrderingSystem_DAO.KoiOrderingSystemInJapanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnimalVarietyId"] = new SelectList(_context.AnimalVarieties, "AnimalVarietyId", "AnimalVarietyId");
        ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmId");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Animals == null || Animal == null)
            {
                return Page();
            }

            _context.Animals.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
