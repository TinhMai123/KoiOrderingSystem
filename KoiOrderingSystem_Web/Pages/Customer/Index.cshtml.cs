using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IKoiService _koiService;
        public List<Koi> Kois { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IKoiService koiService)
        {
            _logger = logger;
            _koiService = koiService;
        }

        public async void OnGet()
        {
            Kois = await _koiService.GetAlls();
        }

    }
}
