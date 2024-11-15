using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_BusinessObject.ViewModels;
using KoiOrderingSystem_Web.Utils;

namespace KoiOrderingSystem_Web.Pages.Admin.Kois
{
    public class IndexModel : PageModel
    {
        private readonly IKoiService _service;

        public IndexModel(IKoiService service)
        {
           _service = service;
        }

        public IList<KoiViewModel> Kois { get;set; } = default!;

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
            var list = await _service.GetAllViewModel();
            if (list != null)
            {
                Kois = list;
            }
            return Page();
        }
    }
}
