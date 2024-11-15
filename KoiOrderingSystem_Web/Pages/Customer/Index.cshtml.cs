using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_Web.Pages.Customer;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages
{
    public class IndexModel : AuthPageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IKoiService _koiService;
        public List<Koi> Kois { get; set; }
        public bool ItemAddedToCart { get; set; } = false;
        public IndexModel(ILogger<IndexModel> logger, IKoiService koiService)
        {
            _logger = logger;
            _koiService = koiService;
        }

        public async void OnGet()
        {
            Kois = await _koiService.GetAlls();
            if (TempData["ItemAdded"] != null)
            {
                ItemAddedToCart = true;
            }
        }
        public async Task<IActionResult> OnPostAddToCart(int koiId)
        {
            var cart = JsonUtils.FromJson<List<Koi>>(HttpContext.Session.GetString("Cart")) ?? new List<Koi>();
            var koi = await _koiService.ReadById(koiId);
            if(koi == null)
            {
                return NotFound();
            }
            // Add the selected koi item ID to the cart
            cart.Add(koi);

            // Save the updated cart back to session
            HttpContext.Session.SetString("Cart", JsonUtils.ToJson(cart));

            // Set TempData for notification
            TempData["ItemAdded"] = true;

            // Redirect back to the main page
            return RedirectToPage("Index");
        }
    }
}
