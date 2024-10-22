using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.impl;

namespace KoiOrderingSystem_Service
{
    public class FarmKoiTypeService : IFarmKoiTypeService
    {
        private readonly IFarmKoiTypeRepository _farmKoiTypeRepository;

        // Constructor to initialize the repository
        public FarmKoiTypeService(IFarmKoiTypeRepository farmKoiTypeRepository)
        {
            _farmKoiTypeRepository = farmKoiTypeRepository ?? throw new ArgumentNullException(nameof(farmKoiTypeRepository));
        }

        // Add a new FarmKoiType
        public void AddFarmKoiType(FarmKoiType newFarm)
        {
            if (newFarm == null)
            {
                throw new ArgumentNullException(nameof(newFarm), "FarmKoiType cannot be null.");
            }
            _farmKoiTypeRepository.AddFarmKoiType(newFarm);
        }

        // Retrieve all FarmKoiType records
        public List<FarmKoiType> GetAllFarms()
        {
            return _farmKoiTypeRepository.GetAllFarms();
        }

        // Retrieve a FarmKoiType by ID
        public FarmKoiType GetFarmById(int id)
        {
            return _farmKoiTypeRepository.GetFarmById(id);
        }

        // Update an existing FarmKoiType
        public void UpdateFarm(FarmKoiType farmKoiType)
        {
            if (farmKoiType == null)
            {
                throw new ArgumentNullException(nameof(farmKoiType), "FarmKoiType cannot be null.");
            }
            _farmKoiTypeRepository.UpdateFarm(farmKoiType);
        }

        // Delete a FarmKoiType
        public void DeleteFarm(FarmKoiType farmKoiType)
        {
            if (farmKoiType == null)
            {
                throw new ArgumentNullException(nameof(farmKoiType), "FarmKoiType cannot be null.");
            }
            _farmKoiTypeRepository.DeleteFarm(farmKoiType);
        }
    }
}