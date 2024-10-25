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

    public class PaymentService : IPaymentService
    {
        private readonly IBaseRepository<Payment> _paymentRepository;
        private readonly IPaymentRepo _repo;

        // Constructor to initialize the repository
        public PaymentService(IBaseRepository<Payment> paymentRepository, IPaymentRepo repo)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Payment
        public async Task<bool> AddAsync(Payment add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Payment cannot be null.");
            }
            return await _paymentRepository.AddAsync(add);
        }

        // Retrieve all Payment records
        public async Task<List<Payment>> GetAlls()
        {
            return await _paymentRepository.GetAllAsync();
        }

        // Retrieve a Payment by ID
        public async Task<Payment?> GetById(int id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        // Update an existing Payment
        public async Task<bool> UpdateAsync(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment), "Payment cannot be null.");
            }
            return await _paymentRepository.UpdateAsync(payment);
        }

        // Delete a Payment
        public async Task<bool> DeleteAsync(int id)
        {
            return await _paymentRepository.DeleteAsync(id);
        }
    }
}
