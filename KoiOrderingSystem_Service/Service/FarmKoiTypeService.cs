using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class FarmKoiTypeService : IFarmKoiTypeService
    {
        private readonly IFarmKoiTypeRepo _repo;



        // Constructor to initialize the repository
        public FarmKoiTypeService( IFarmKoiTypeRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new FarmKoiType
        public async Task<bool> AddAsync(FarmKoiType newFarm)
        {
            if (newFarm == null)
            {
                throw new ArgumentNullException(nameof(newFarm), "FarmKoiType cannot be null.");
            }
            if (newFarm.Quantity < 0)
            {
                throw new Exception("Cannot have a quantity of 0");
            }
            return await _repo.Add(newFarm);
        }

        // Retrieve all FarmKoiType records
        public async Task<List<FarmKoiType>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a FarmKoiType by ID
        public async Task<FarmKoiType?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing FarmKoiType
        public async Task<bool> UpdateAsync(FarmKoiType farmKoiType)
        {
            if (farmKoiType == null)
            {
                throw new ArgumentNullException(nameof(farmKoiType), "FarmKoiType cannot be null.");
            }
            return await _repo.Update(farmKoiType);
        }

        // Delete a FarmKoiType
        public  async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        public async Task<List<FarmKoiType>> ReadAlls()
        {
            return await _repo.ReadAll();
        }

        public async Task<FarmKoiType?> ReadById(int id)
        {
            return await _repo.ReadById(id);
        }
    }
}