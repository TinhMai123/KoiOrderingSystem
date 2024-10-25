using System;
using System.Collections.Generic;
using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class FarmKoiTypeService : IFarmKoiTypeService
    {
        private readonly IBaseRepository<FarmKoiType> _farmKoiTypeRepository;
        private readonly IFarmKoiTypeRepo _repo;



        // Constructor to initialize the repository
        public FarmKoiTypeService(IBaseRepository<FarmKoiType> farmKoiTypeRepository, IFarmKoiTypeRepo repo)
        {
            _farmKoiTypeRepository = farmKoiTypeRepository ?? throw new ArgumentNullException(nameof(farmKoiTypeRepository));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new FarmKoiType
        public async Task<bool> AddAsync(FarmKoiType newFarm)
        {
            if (newFarm == null)
            {
                throw new ArgumentNullException(nameof(newFarm), "FarmKoiType cannot be null.");
            }
            return await _farmKoiTypeRepository.AddAsync(newFarm);
        }

        // Retrieve all FarmKoiType records
        public async Task<List<FarmKoiType>> GetAlls()
        {
            return await _farmKoiTypeRepository.GetAllAsync();
        }

        // Retrieve a FarmKoiType by ID
        public async Task<FarmKoiType?> GetById(int id)
        {
            return await _farmKoiTypeRepository.GetByIdAsync(id);
        }

        // Update an existing FarmKoiType
        public async Task<bool> UpdateAsync(FarmKoiType farmKoiType)
        {
            if (farmKoiType == null)
            {
                throw new ArgumentNullException(nameof(farmKoiType), "FarmKoiType cannot be null.");
            }
            return await _farmKoiTypeRepository.UpdateAsync(farmKoiType);
        }

        // Delete a FarmKoiType
        public  async Task<bool> DeleteAsync(int id)
        {
            return await _farmKoiTypeRepository.DeleteAsync(id);
        }
    }
}