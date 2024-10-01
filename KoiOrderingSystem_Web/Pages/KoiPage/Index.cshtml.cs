using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;

namespace KoiOrderingSystem_Web.Pages.KoiPage
{
    public class IndexModel : PageModel
    {
        private readonly KoiOrderingSystem_DAO.KoiOrderingSystemInJapanContext _context;

        public IndexModel(KoiOrderingSystem_DAO.KoiOrderingSystemInJapanContext context)
        {
            _context = context;
        }

        public IList<Animal> Animal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Animals != null)
            {
                Animal = await _context.Animals
                .Include(a => a.AnimalVariety)
                .Include(a => a.Farm).ToListAsync();
            }
        }
    }
}
