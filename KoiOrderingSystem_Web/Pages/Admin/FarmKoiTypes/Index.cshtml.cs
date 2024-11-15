using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Web.Utils;

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class IndexModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public IndexModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IList<FarmKoiType> FarmKoiType { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var userString = HttpContext.Session.GetString("User") ?? "";
            if (string.IsNullOrEmpty(userString))
            {
                return Redirect("/Login");
            }
            var user = JsonUtils.FromJson<User>(userString);
            if (user == null || user.Role != "Admin")
            {
                return Redirect("/Login");
            }
            if (_context.FarmKoiTypes != null)
            {
                FarmKoiType = await _context.FarmKoiTypes
                .Include(f => f.Farm)
                .Include(f => f.KoiType).ToListAsync();
            }
            return Page();
        }
    }
}
