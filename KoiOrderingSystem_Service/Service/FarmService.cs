using System;
using System.Collections.Generic;
using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class FarmService : IFarmService
    {
        private readonly IBaseRepository<Farm> _farmRepository;
        private readonly IFarmRepo _repo;



        // Constructor to initialize the repository
        public FarmService(IBaseRepository<Farm> farmRepository, IFarmRepo repo)
        {
            _farmRepository = farmRepository ?? throw new ArgumentNullException(nameof(farmRepository));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Farm
        public async Task<bool> AddAsync(Farm newFarm)
        {
            if (newFarm == null)
            {
                throw new ArgumentNullException(nameof(newFarm), "Farm cannot be null.");
            }
            return await _farmRepository.AddAsync(newFarm);
        }

        // Retrieve all Farms
        public async Task<List<Farm>> GetAlls()
        {
            return await _farmRepository.GetAllAsync();
        }

        // Retrieve a Farm by ID
        public async Task<Farm?> GetById(int id)
        {
            return await _farmRepository.GetByIdAsync(id);
        }

        // Update an existing Farm
        public async Task<bool> UpdateAsync(Farm update)
        {
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update), "Farm cannot be null.");
            }
            return await _farmRepository.UpdateAsync(update);
        }

        // Delete a Farm
        public async Task<bool> DeleteAsync(int id)
        {
           return await _farmRepository.DeleteAsync(id);
        }
    }
}