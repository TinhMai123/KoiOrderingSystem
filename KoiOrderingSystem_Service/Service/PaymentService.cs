
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
        private readonly IPaymentRepo _repo;

        // Constructor to initialize the repository
        public PaymentService( IPaymentRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Payment
        public async Task<bool> AddAsync(Payment add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Payment cannot be null.");
            }
            return await _repo.Add(add);
        }

        // Retrieve all Payment records
        public async Task<List<Payment>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a Payment by ID
        public async Task<Payment?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing Payment
        public async Task<bool> UpdateAsync(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment), "Payment cannot be null.");
            }
            return await _repo.Update(payment);
        }

        // Delete a Payment
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }
    }
}
