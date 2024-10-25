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

    public class OrderTripService : IOrderTripService
    {
        private readonly IBaseRepository<OrderTrip> _orderTripRepository;
        private readonly IOrderTripRepo _repo;



        // Constructor to initialize the repository
        public OrderTripService(IBaseRepository<OrderTrip> orderTripRepository)
        {
            _orderTripRepository = orderTripRepository ?? throw new ArgumentNullException(nameof(orderTripRepository));
        }

        // Add a new OrderTrip
        public async Task<bool> AddAsync(OrderTrip add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "OrderTrip cannot be null.");
            }
            return await _orderTripRepository.AddAsync(add);
        }

        // Retrieve all OrderTrip records
        public async Task<List<OrderTrip>> GetAlls()
        {
            return await _orderTripRepository.GetAllAsync();
        }

        // Retrieve a OrderTrip by ID
        public async Task<OrderTrip?> GetById(int id)
        {
            return await _orderTripRepository.GetByIdAsync(id);
        }

        // Update an existing OrderTrip
        public async Task<bool> UpdateAsync(OrderTrip orderTrip)
        {
            if (orderTrip == null)
            {
                throw new ArgumentNullException(nameof(orderTrip), "OrderTrip cannot be null.");
            }
            return await _orderTripRepository.UpdateAsync(orderTrip);
        }

        // Delete a OrderTrip
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderTripRepository.DeleteAsync(id);
        }
    }
}
