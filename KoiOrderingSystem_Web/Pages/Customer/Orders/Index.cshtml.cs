using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IOrderKoiService _orderKoiService;
        private readonly IOrderTripService _orderTripService;

        public IndexModel(IOrderService orderService, IOrderKoiService orderKoiService, IOrderTripService orderTripService)
        {
            _orderService = orderService;
            _orderKoiService = orderKoiService;
            _orderTripService = orderTripService;
        }

        public IList<Order> Orders { get; set; } = default!;
        public IList<OrderTrip> OrderTrips { get; set; } = default!;
        public IList<OrderKoi> OrderKois { get; set; } = default!;
        public string? Message { get; set; } = null;
        public async Task OnGetAsync()
        {
            try { Orders = await _orderService.GetAlls();
                OrderTrips = await _orderTripService.GetAlls();
                OrderKois = await _orderKoiService.GetAlls();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while retrieving orders.";
                RedirectToPage("../Error");
            }
        }
    }
}

