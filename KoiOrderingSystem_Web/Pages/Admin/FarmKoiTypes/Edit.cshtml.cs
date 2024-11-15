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

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class EditModel : PageModel
    {
        private readonly IFarmKoiTypeService _farmKoiTypeService;
        private readonly IFarmService _farmService;


        public EditModel(IFarmKoiTypeService farmKoiTypeService)
        {
            _farmKoiTypeService = farmKoiTypeService;
        }

        [BindProperty]
        public FarmKoiType FarmKoiType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmkoitype =  await _farmKoiTypeService.GetById((int)id);
            if (farmkoitype == null)
            {
                return NotFound();
            }
            FarmKoiType = farmkoitype;
           ViewData["FarmId"] = new SelectList(await _farmService.GetAlls(), "Id", "Description");
           ViewData["KoiTypeId"] = new SelectList(await _farmKoiTypeService.GetAlls(), "Id", "Name");
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
                await _farmKoiTypeService.UpdateAsync(FarmKoiType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmKoiTypeExists(FarmKoiType.Id))
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

        private bool FarmKoiTypeExists(int id)
        {
          return _farmKoiTypeService.GetById((int)id) != null;
        }
    }
}
