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

namespace KoiOrderingSystem_Web.Pages.Admin.Farms
{
    public class DeleteModel : PageModel
    {
        private readonly IFarmService _service;

        public DeleteModel(IFarmService service)
        {
            _service = service;
        }

        [BindProperty]
      public Farm Farm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _service.ReadAlls() == null)
            {
                return NotFound();
            }

            var farm = await _service.ReadById(id.Value);
            if (farm == null)
            {
                return NotFound();
            }
            else 
            {
                Farm = farm;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || await _service.ReadAlls() == null)
            {
                return NotFound();
            }
            var farm = await _service.ReadById(id.Value);

            if (farm != null)
            {
                Farm = farm;
                await _service.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
