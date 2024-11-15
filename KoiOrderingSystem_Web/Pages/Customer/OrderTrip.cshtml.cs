using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer
{
    public class OrderTripModel : PageModel
    {
        private readonly IOrderTripService _service;

        public OrderTripModel(IOrderTripService service)
        {
            _service = service;
        }

        public List<OrderTrip> OrderTrips { get; set; }
        public async Task OnGet()
        {
           var list = await _service.ReadAlls();
            if(list != null)
            {
                OrderTrips = list;
            }
            ViewData["FarmName"] = "a";
        }
    }
}
