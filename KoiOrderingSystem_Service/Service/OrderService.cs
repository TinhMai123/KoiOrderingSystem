
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

    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _repo;



        // Constructor to initialize the repository
        public OrderService( IOrderRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));  
        }

        // Add a new Order
        public async Task<bool> AddAsync(Order add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Order cannot be null.");
            }
            if(add.TotalAmount < 0)
            {
                throw new Exception("Amount cannot be smaller than 0");
            }
            return await _repo.Add(add);
        }

        // Retrieve all Order records
        public async Task<List<Order>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a Order by ID
        public async Task<Order?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing Order
        public async Task<bool> UpdateAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }
            if (order.TotalAmount < 0)
            {
                throw new Exception("Amount cannot be smaller than 0");
            }
            return await _repo.Update(order);
        }

        // Delete a Order
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }
    }
}
