using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Web.Pages.Admin.KoiByBatches
{
    public class EditModel : PageModel
    {
        private readonly IKoiByBatchService _service;

        public EditModel(IKoiByBatchService service)
        {
            _service = service;
        }

        [BindProperty]
        public KoiByBatch KoiByBatch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _service.ReadAlls() == null)
            {
                return NotFound();
            }

            var koibybatch = await _service.ReadById(id.Value);
            if (koibybatch == null)
            {
                return NotFound();
            }
            KoiByBatch = koibybatch;
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

            try
            {
                await _service.UpdateAsync(KoiByBatch);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await KoiByBatchExists(KoiByBatch.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while updating the KoiByBatch: {ex.Message}");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> KoiByBatchExists(int id)
        {
            return await _service.ReadById(id) != null;
        }

    }
}
