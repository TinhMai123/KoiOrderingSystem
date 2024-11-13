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

namespace KoiOrderingSystem_Web.Pages.Admin.KoiTypes
{
    public class CreateModel : PageModel
    {
        private readonly IKoiTypeService _service;

        public CreateModel(IKoiTypeService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KoiType KoiType { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (KoiType == null)
            {
                ModelState.AddModelError("KoiType", "KoiType is required.");
            }

            if (string.IsNullOrEmpty(KoiType.Name))
            {
                ModelState.AddModelError("KoiType.Name", "Name is required.");
            }

            var check = await _service.ReadAlls();
            if (check.Any(c => c.Name.ToLower() == KoiType.Name.ToLower()))
            {
                ModelState.AddModelError("KoiType.Name", $"The name {KoiType.Name} is already taken.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _service.AddAsync(KoiType);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}
