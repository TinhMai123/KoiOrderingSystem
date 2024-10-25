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
    public class InsuranceService : IInsuranceRepo
    {
        private readonly IBaseRepository<Insurance> _insuranceRepository;


        // Constructor to initialize the repository
        public InsuranceService(IBaseRepository<Insurance> insuaranceRepository)
        {
            _insuranceRepository = insuaranceRepository ?? throw new ArgumentNullException(nameof(insuaranceRepository));
        }

        // Add a new InsuaranceService
        public async Task<bool> AddAsync(Insurance add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "InsuaranceService cannot be null.");
            }
            return await _insuranceRepository.AddAsync(add);
        }

        // Retrieve all InsuaranceService records
        public async Task<List<Insurance>> GetAlls()
        {
            return await _insuranceRepository.GetAllAsync();
        }

        // Retrieve a InsuaranceService by ID
        public async Task<Insurance?> GetById(int id)
        {
            return await _insuranceRepository.GetByIdAsync(id);
        }

        // Update an existing InsuaranceService
        public async Task<bool> UpdateAsync(Insurance insurance)
        {
            if (insurance == null)
            {
                throw new ArgumentNullException(nameof(insurance), "InsuaranceService cannot be null.");
            }
            return await _insuranceRepository.UpdateAsync(insurance);
        }

        // Delete a InsuaranceService
        public async Task<bool> DeleteAsync(int id)
        {
            return await _insuranceRepository.DeleteAsync(id);
        }
    }
}
