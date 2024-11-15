using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer
{
    public class CartModel : AuthPageModel
    {
        private readonly IKoiService _koiService;

        public CartModel(IKoiService koiService)
        {
            _koiService = koiService;
        }

        public List<Koi> CartItems { get; set; }
        public float CartTotal { get; set; }
        public void OnGet()
        {
            var cartSession = HttpContext.Session.GetString("Cart");
            if (!string.IsNullOrEmpty(cartSession))
            {
                CartItems = JsonUtils.FromJson<List<Koi>>(cartSession);
                CalculateCartTotal();
            }
        }
        private void CalculateCartTotal()
        {
            CartTotal = CartItems.Sum(item => item.Weight);
        }
        public IActionResult OnPostRemoveFromCart(int id)
        {
            // Remove the item from the cart based on its ID
            CartItems = CartItems.Where(item => item.Id != id).ToList();
            HttpContext.Session.SetString("Cart", JsonUtils.ToJson(CartItems));
            CalculateCartTotal();

            return RedirectToPage();
        }
    }
}
