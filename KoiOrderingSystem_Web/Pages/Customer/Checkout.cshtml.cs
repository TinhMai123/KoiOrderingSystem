using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer
{
    public class CheckoutModel : AuthPageModel
    {
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
    }
}
