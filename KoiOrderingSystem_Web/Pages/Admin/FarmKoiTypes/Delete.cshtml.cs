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

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class DeleteModel : PageModel
    {
        private readonly IFarmKoiTypeService _farmKoiTypeService;

        public DeleteModel(IFarmKoiTypeService farmKoiTypeService)
        {
            _farmKoiTypeService = farmKoiTypeService;
        }

        [BindProperty]
      public FarmKoiType FarmKoiType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var farmkoitype = await _farmKoiTypeService.GetById((int)id);

            if (farmkoitype == null)
            {
                return NotFound();
            }
            else 
            {
                FarmKoiType = farmkoitype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var farmkoitype = await _farmKoiTypeService.GetById((int)id); ;

            if (farmkoitype != null)
            {
                _farmKoiTypeService.DeleteAsync((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
