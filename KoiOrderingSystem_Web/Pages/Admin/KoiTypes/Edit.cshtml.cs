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

namespace KoiOrderingSystem_Web.Pages.Admin.KoiTypes
{
    public class EditModel : PageModel
    {
        private readonly IKoiTypeService _service;

        public EditModel(IKoiTypeService service)
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

            var koitype = await _service.GetById(id.Value);
            if (koitype == null)
            {
                return NotFound();
            }
            KoiType = koitype;
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
                await _service.UpdateAsync(KoiType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await KoiTypeExists(KoiType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> KoiTypeExists(int id)
        {
          return await _service.ReadById(id) == null;
        }
    }
}
