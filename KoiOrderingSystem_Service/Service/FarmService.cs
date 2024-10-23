using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;

        // Constructor to initialize the repository
        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository ?? throw new ArgumentNullException(nameof(farmRepository));
        }

        // Add a new Farm
        public void AddFarm(Farm newFarm)
        {
            if (newFarm == null)
            {
                throw new ArgumentNullException(nameof(newFarm), "Farm cannot be null.");
            }
            _farmRepository.AddFarm(newFarm);
        }

        // Retrieve all Farms
        public List<Farm> GetAllFarms()
        {
            return _farmRepository.GetAllFarms();
        }

        // Retrieve a Farm by ID
        public Farm GetFarmById(int id)
        {
            return _farmRepository.GetFarmById(id);
        }

        // Update an existing Farm
        public void UpdateFarm(Farm farmToUpdate)
        {
            if (farmToUpdate == null)
            {
                throw new ArgumentNullException(nameof(farmToUpdate), "Farm cannot be null.");
            }
            _farmRepository.UpdateFarm(farmToUpdate);
        }

        // Delete a Farm
        public void DeleteFarm(Farm farm)
        {
            if (farm == null)
            {
                throw new ArgumentNullException(nameof(farm), "Farm cannot be null.");
            }
            _farmRepository.DeleteFarm(farm);
        }
    }
}