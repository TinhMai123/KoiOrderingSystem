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
using KoiOrderingSystem_Service.Service;

namespace KoiOrderingSystem_Web.Pages.Admin.Kois
{
    public class EditModel : PageModel
    {
        private readonly IKoiService _service;
        private readonly IKoiTypeService _typeService;
        private readonly IFarmService _farmService;
        public EditModel(IKoiService service, IKoiTypeService typeService, IFarmService farmService)
        {
            _service = service;
            _typeService = typeService;
            _farmService = farmService;
        }

        [BindProperty]
        public Koi Koi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _service.ReadAlls() == null)
            {
                return NotFound();
            }
            ViewData["KoiTypeId"] = new SelectList(await _typeService.GetAlls(), "Id", "Name");
            ViewData["FarmId"] = new SelectList(await _farmService.GetAlls(), "Id", "FarmName");
            var koi = await _service.ReadById(id.Value);
            if (koi == null)
            {
                return NotFound();
            }
            Koi = koi;
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
                await _service.UpdateAsync(Koi);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await KoiExists(Koi.Id))
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

        private async Task<bool> KoiExists(int id)
        {
            return await _service.ReadById(id) == null;
        }
    }
}
