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

namespace KoiOrderingSystem_Web.Pages.Admin.KoiByBatches
{
    public class IndexModel : PageModel
    {
        private readonly IKoiByBatchService _service;

        public IndexModel(IKoiByBatchService service)
        {
            _service = service;
        }

        public IList<KoiByBatch> KoiByBatch { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var list = await _service.ReadAlls();
            if (list != null)
            {
                KoiByBatch = list;
            }
        }
    }
}
