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
        public class OrderKoiService : IOrderKoiService
        {
            private readonly IBaseRepository<OrderKoi> _orderKoiRepository;
        private readonly IOrderKoiRepo _repo;



        // Constructor to initialize the repository
        public OrderKoiService(IBaseRepository<OrderKoi> orderKoiRepository)
            {
                _orderKoiRepository = orderKoiRepository ?? throw new ArgumentNullException(nameof(orderKoiRepository));
            }

            // Add a new OrderKoi
            public async Task<bool> AddAsync(OrderKoi add)
            {
                if (add == null)
                {
                    throw new ArgumentNullException(nameof(add), "OrderKoi cannot be null.");
                }
                return await _orderKoiRepository.AddAsync(add);
            }

            // Retrieve all OrderKoi records
            public async Task<List<OrderKoi>> GetAlls()
            {
                return await _orderKoiRepository.GetAllAsync();
            }

            // Retrieve a OrderKoi by ID
            public async Task<OrderKoi?> GetById(int id)
            {
                return await _orderKoiRepository.GetByIdAsync(id);
            }

            // Update an existing OrderKoi
            public async Task<bool> UpdateAsync(OrderKoi orderKoi)
            {
                if (orderKoi == null)
                {
                    throw new ArgumentNullException(nameof(orderKoi), "OrderKoi cannot be null.");
                }
                return await _orderKoiRepository.UpdateAsync(orderKoi);
            }

            // Delete a OrderKoi
            public async Task<bool> DeleteAsync(int id)
            {
                return await _orderKoiRepository.DeleteAsync(id);
            }
        }
    
}
