using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.Service
{

    public class OrderDetailKoiService : IOrderDetailKoiService
    {
        private readonly IBaseRepository<OrderDetailKoi> _orderDetailKoiRepository;
        private readonly IOrderDetailKoiRepo _repo;



        // Constructor to initialize the repository
        public OrderDetailKoiService(IBaseRepository<OrderDetailKoi> orderDetailKoiRepository)
        {
            _orderDetailKoiRepository = orderDetailKoiRepository ?? throw new ArgumentNullException(nameof(orderDetailKoiRepository));
        }

        // Add a new OrderDetailKoi
        public async Task<bool> AddAsync(OrderDetailKoi add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "OrderDetailKoi cannot be null.");
            }
            return await _orderDetailKoiRepository.AddAsync(add);
        }

        // Retrieve all OrderDetailKoi records
        public async Task<List<OrderDetailKoi>> GetAlls()
        {
            return await _orderDetailKoiRepository.GetAllAsync();
        }

        // Retrieve a OrderDetailKoi by ID
        public async Task<OrderDetailKoi?> GetById(int id)
        {
            return await _orderDetailKoiRepository.GetByIdAsync(id);
        }

        // Update an existing OrderDetailKoi
        public async Task<bool> UpdateAsync(OrderDetailKoi orderDetailKoi)
        {
            if (orderDetailKoi == null)
            {
                throw new ArgumentNullException(nameof(orderDetailKoi), "OrderDetailKoi cannot be null.");
            }
            return await _orderDetailKoiRepository.UpdateAsync(orderDetailKoi);
        }

        // Delete a OrderDetailKoi
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderDetailKoiRepository.DeleteAsync(id);
        }
    }
}
