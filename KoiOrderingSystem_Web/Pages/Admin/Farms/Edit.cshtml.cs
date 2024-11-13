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

        // Manual validation in OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            // Manual validation checks
            if (string.IsNullOrEmpty(Farm.FarmName))
            {
                ModelState.AddModelError("Farm.FarmName", "Farm name is required.");
            }

            if (string.IsNullOrEmpty(Farm.Location))
            {
                ModelState.AddModelError("Farm.Location", "Location is required.");
            }

            if (Farm.EstablishedYear < 1500 || Farm.EstablishedYear > DateTime.UtcNow.Year)
            {
                ModelState.AddModelError("Farm.EstablishedYear", "Established Year must be between 1500 and the current year.");
            }

            // Checking if the farm name already exists
            var allFarms = await _service.ReadAlls();
            var farmWithSameName = allFarms.FirstOrDefault(f => f.FarmName.Equals(Farm.FarmName, StringComparison.OrdinalIgnoreCase) && f.Id != Farm.Id);
            if (farmWithSameName != null)
            {
                ModelState.AddModelError("Farm.FarmName", $"The farm name '{Farm.FarmName}' is already taken.");
            }

            // If model state is not valid, return to the page with validation errors
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
                if (!await FarmExists(Farm.Id))
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

        // Check if the farm exists by its Id
        private async Task<bool> FarmExists(int id)
        {
            return await _service.ReadById(id) == null;
        }
    }

}
