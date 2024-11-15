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

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class CreateModel : PageModel
    {
        private readonly IFarmKoiTypeService _farmKoiTypeService;
        private readonly IFarmService _farmService;
        private readonly IKoiTypeService _koiTypeService;

        public CreateModel(IFarmKoiTypeService farmKoiType, IFarmService farmService, IKoiTypeService koiTypeService)
        {
            _farmKoiTypeService = farmKoiType;
            _farmService = farmService;
            _koiTypeService = koiTypeService;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["FarmId"] = new SelectList(await _farmService.GetAlls(), "Id", "Description");
        ViewData["KoiTypeId"] = new SelectList(await _koiTypeService.GetAlls(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public FarmKoiType FarmKoiType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid )
            {
                return Page();
            }

            await _farmKoiTypeService.AddAsync(FarmKoiType);

            return RedirectToPage("./Index");
        }
    }
}
