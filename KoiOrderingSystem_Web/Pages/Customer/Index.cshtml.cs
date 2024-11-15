using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.ViewModels;
using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_Web.Pages.Customer;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IKoiService _koiService;
        public List<KoiViewModel> Kois { get; set; }
        public bool ItemAddedToCart { get; set; } = false;
        public IndexModel(ILogger<IndexModel> logger, IKoiService koiService)
        {
            _logger = logger;
            _koiService = koiService;
        }

        public async Task OnGet()
        {
            Kois = await _koiService.GetAllViewModel();
            var account = HttpContext.Session.GetString("User");
            if (!string.IsNullOrEmpty(account))
            {
                ViewData["User"] = JsonUtils.FromJson<User>(account);
            }
        }
        public async Task<IActionResult> OnPostAddToCart(int koiId)
        {
            var json = HttpContext.Session.GetString("Cart");
            var cart = new List<Koi>();
            if(json != null) {
                cart = JsonUtils.FromJson<List<Koi>>(json);
            }
            var koi = await _koiService.ReadById(koiId);
            if(koi == null)
            {
                return NotFound();
            }
            // Add the selected koi item ID to the cart
            cart.Add(koi);

            // Save the updated cart back to session
            HttpContext.Session.SetString("Cart", JsonUtils.ToJson(cart));
            ItemAddedToCart = true;

            // Redirect back to the main page
            return Redirect("/");
        }
    }
}
