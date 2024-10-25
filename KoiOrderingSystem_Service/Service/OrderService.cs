using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.Service
{

    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _orderRepository;


        // Constructor to initialize the repository
        public OrderService(IBaseRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        // Add a new Order
        public async Task<bool> AddAsync(Order add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Order cannot be null.");
            }
            return await _orderRepository.AddAsync(add);
        }

        // Retrieve all Order records
        public async Task<List<Order>> GetAlls()
        {
            return await _orderRepository.GetAllAsync();
        }

        // Retrieve a Order by ID
        public async Task<Order?> GetById(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        // Update an existing Order
        public async Task<bool> UpdateAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }
            return await _orderRepository.UpdateAsync(order);
        }

        // Delete a Order
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }
    }
}
