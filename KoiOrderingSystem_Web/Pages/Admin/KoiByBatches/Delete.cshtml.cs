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

namespace KoiOrderingSystem_Web.Pages.Admin.KoiByBatches
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiByBatchService _service;

        public DeleteModel(IKoiByBatchService service)
        {
            _service = service;
        }

        [BindProperty]
      public KoiByBatch KoiByBatch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null ||await _service.ReadAlls() == null)
            {
                return NotFound();
            }

            var koibybatch = await _service.ReadById(id.Value);

            if (koibybatch == null)
            {
                return NotFound();
            }
            else 
            {
                KoiByBatch = koibybatch;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _service.ReadAlls() == null)
            {
                return NotFound();
            }
            var koibybatch = await _service.ReadById(id.Value);

            if (koibybatch != null)
            {
                KoiByBatch = koibybatch;
                await _service.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
