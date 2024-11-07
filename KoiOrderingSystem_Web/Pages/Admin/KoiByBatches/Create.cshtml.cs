﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;

namespace KoiOrderingSystem_Web.Pages.Admin.KoiByBatches
{
    public class CreateModel : PageModel
    {
        private readonly KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext _context;

        public CreateModel(KoiOrderingSystem_BusinessObject.Data.KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["KoiTypeId"] = new SelectList(_context.KoiTypes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public KoiByBatch KoiByBatch { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.KoiByBatches == null || KoiByBatch == null)
            {
                return Page();
            }

            _context.KoiByBatches.Add(KoiByBatch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}