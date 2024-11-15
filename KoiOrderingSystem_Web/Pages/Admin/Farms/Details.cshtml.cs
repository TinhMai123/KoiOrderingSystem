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
using KoiOrderingSystem_BusinessObject.ViewModels;

namespace KoiOrderingSystem_Web.Pages.Admin.Farms
{
    public class DetailsModel : PageModel
    {
        private readonly IFarmService _service;
        private readonly IFarmKoiTypeService _farmKoiTypeService;
        private readonly IKoiService _koiService;

        public DetailsModel(IFarmService service, IFarmKoiTypeService farmKoiTypeService, IKoiService koiService)
        {
            _service = service;
            _farmKoiTypeService = farmKoiTypeService;
            _koiService = koiService;
        }

        public Farm Farm { get; set; } = default!; 
        public List<FarmKoiType> FarmKoiTypes { get; set; } = new List<FarmKoiType>();
        public List<KoiViewModel> Kois { get; set; } = new List<KoiViewModel>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            FarmKoiTypes = (await _farmKoiTypeService.GetAlls()).Where(
                fk => fk.FarmId == id
                ).ToList();
            Kois = (await _koiService.GetAllViewModel()).Where(
                vm => vm.Koi.FarmId == id
                ).ToList();
            if (id == null)
            {
                return NotFound();
            }

            var farm = await _service.GetById(id.Value);
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
    }
}
