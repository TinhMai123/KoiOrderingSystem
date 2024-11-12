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

namespace KoiOrderingSystem_Web.Pages.Admin.Kois
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiService _service;

        public DetailsModel(IKoiService service)
        {
            _service = service;
        }

      public Koi Koi { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _service.ReadAlls() == null)
            {
                return NotFound();
            }

            var koi = await _service.ReadById(id.Value);
            if (koi == null)
            {
                return NotFound();
            }
            else 
            {
                Koi = koi;
            }
            return Page();
        }
    }
}
