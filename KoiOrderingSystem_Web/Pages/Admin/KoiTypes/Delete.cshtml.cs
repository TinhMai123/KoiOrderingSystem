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
    public class DeleteModel : PageModel
    {
        private readonly IKoiTypeService _service;

        public DeleteModel(IKoiTypeService service)
        {
            _service = service;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var koitype = await _service.GetById(id.Value);

            if (koitype != null)
            {
                KoiType = koitype;
                await _service.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
