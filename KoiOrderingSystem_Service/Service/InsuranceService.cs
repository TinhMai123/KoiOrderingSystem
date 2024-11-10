
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
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepo _repo;

        // Constructor to initialize the repository
        public InsuranceService(IInsuranceRepo repo) { 
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new InsuaranceService
        public async Task<bool> AddAsync(Insurance add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "Insuarance cannot be null.");
            }
            if(add.Price < 0)
            {
                throw new Exception("We do not accept number under 0");
            }
            return await _repo.Add(add);
        }

        // Retrieve all InsuaranceService records
        public async Task<List<Insurance>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a InsuaranceService by ID
        public async Task<Insurance?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing InsuaranceService
        public async Task<bool> UpdateAsync(Insurance insurance)
        {
            if (insurance == null)
            {
                throw new ArgumentNullException(nameof(insurance), "InsuaranceService cannot be null.");
            }
            if (insurance.Price < 0)
            {
                throw new Exception("We do not accept number under 0");
            }
            return await _repo.Update(insurance);
        }

        // Delete a InsuaranceService
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        public async Task<List<Insurance>> ReadAlls()
        {
            return await _repo.ReadAll();
        }

        public async Task<Insurance?> ReadById(int id)
        {
            return await _repo.ReadById(id);
        }
    }
}
