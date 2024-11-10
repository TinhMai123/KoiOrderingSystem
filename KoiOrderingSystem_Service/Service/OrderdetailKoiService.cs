
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
        private readonly IOrderDetailKoiRepo _repo;



        // Constructor to initialize the repository
        public OrderDetailKoiService(IOrderDetailKoiRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new OrderDetailKoi
        public async Task<bool> AddAsync(OrderDetailKoi add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "OrderDetailKoi cannot be null.");
            }
            if (add.Price < 0)
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            return await _repo.Add(add);
        }

        // Retrieve all OrderDetailKoi records
        public async Task<List<OrderDetailKoi>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a OrderDetailKoi by ID
        public async Task<OrderDetailKoi?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing OrderDetailKoi
        public async Task<bool> UpdateAsync(OrderDetailKoi orderDetailKoi)
        {
            if (orderDetailKoi == null)
            {
                throw new ArgumentNullException(nameof(orderDetailKoi), "OrderDetailKoi cannot be null.");
            }
            if (orderDetailKoi.Price < 0)
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            return await _repo.Update(orderDetailKoi);  
        }

        // Delete a OrderDetailKoi
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }
    }
}
