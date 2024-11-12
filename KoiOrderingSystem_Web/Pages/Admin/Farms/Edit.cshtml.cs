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

namespace KoiOrderingSystem_Web.Pages.Admin.Farms
{
    public class EditModel : PageModel
    {
        private readonly IFarmService _service;

        public EditModel(IFarmService service)
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
            Farm = farm;
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
                await _service.UpdateAsync(Farm);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await FarmExists(Farm.Id))
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

        private async Task<bool> FarmExists(int id)
        {
            return await _service.ReadById(id) == null;
        }
    }
}
