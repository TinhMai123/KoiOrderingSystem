using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Web.Pages.Admin.KoiByBatches
{
    public class CreateModel : PageModel
    {
        private readonly IKoiByBatchService _service;
        private readonly IKoiTypeService _typeService;

        public CreateModel(IKoiByBatchService service, IKoiTypeService typeService)
        {
            _service = service;
            _typeService = typeService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["KoiTypeId"] = new SelectList(await _typeService.GetAlls(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public KoiByBatch KoiByBatch { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (KoiByBatch == null)
            {
                ModelState.AddModelError("KoiByBatch", "KoiByBatch data is required.");
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (KoiByBatch.Quantity < 0)
            {
                ModelState.AddModelError("KoiByBatch.Quantity", "Quantity cannot be less than 0.");
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (KoiByBatch.Size < 0)
            {
                ModelState.AddModelError("KoiByBatch.Size", "Size cannot be less than 0.");
            }

            if (KoiByBatch.Price < 0)
            {
                ModelState.AddModelError("KoiByBatch.Price", "Price cannot be less than 0.");
            }

            if (!ModelState.IsValid || await _service.ReadAlls() == null)
            {
                return Page();
            }

            await _service.AddAsync(KoiByBatch);

            return RedirectToPage("./Index");
        }

    }
}
