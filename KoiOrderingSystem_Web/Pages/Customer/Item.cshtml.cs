using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_Service.Service;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer
{
    public class ItemModel : AuthPageModel
    {
        private readonly IKoiService _service;
        public List<Koi> Kois { get; set; } 
        public Koi Main { get; set; }
        public async Task<IActionResult> OnGet(int koiId)
        {
            var koi = await _service.ReadById(koiId);

            if (koi == null)
            {
                return NotFound();
            }
            Main = koi;
            var list = await _service.ReadAlls();
            Kois = list.Where(c=>c.KoiTypeId == koi.KoiTypeId).Take(4).ToList();
            return Page();
           
        }
        public async Task<IActionResult> OnPostAsync(int koiId)
        {
            var cart = JsonUtils.FromJson<List<Koi>>(HttpContext.Session.GetString("Cart")) ?? new List<Koi>();
            var koi = await _service.ReadById(koiId);
            if (koi == null)
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
