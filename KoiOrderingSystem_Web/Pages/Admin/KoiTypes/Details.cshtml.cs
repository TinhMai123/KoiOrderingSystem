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

namespace KoiOrderingSystem_Web.Pages.Admin.KoiTypes
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiTypeService _service;

        public DetailsModel(IKoiTypeService service)
        {
            _service = service;
        }

      public KoiType KoiType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _service.ReadAlls() == null)
            {
                return NotFound();
            }

            var koitype = await _service.ReadById(id.Value);
            if (koitype == null)
            {
                return NotFound();
            }
            else 
            {
                KoiType = koitype;
            }
            return Page();
        }
    }
}
