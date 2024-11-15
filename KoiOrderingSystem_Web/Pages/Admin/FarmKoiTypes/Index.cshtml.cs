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
using KoiOrderingSystem_Service.Service;

namespace KoiOrderingSystem_Web.Pages.Admin.FarmKoiTypes
{
    public class IndexModel : PageModel
    {
        private readonly IFarmKoiTypeService _farmKoiTypeService;

        public IndexModel(IFarmKoiTypeService farmKoiTypeService)
        {
            _farmKoiTypeService = farmKoiTypeService;
        }

        public IList<FarmKoiType> FarmKoiType { get; set; } = default!;

        public async Task OnGetAsync()
        {
            FarmKoiType = await _farmKoiTypeService.GetAlls();
        }
    }
}
