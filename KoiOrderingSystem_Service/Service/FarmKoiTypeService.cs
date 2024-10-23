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
        private readonly IFarmKoiTypeRepo _farmKoiTypeRepository;
        
        // Constructor to initialize the repository
        public FarmKoiTypeService(IFarmKoiTypeRepo farmKoiTypeRepository)
        {
            _farmKoiTypeRepository = farmKoiTypeRepository ?? throw new ArgumentNullException(nameof(farmKoiTypeRepository));
        }

        // Add a new FarmKoiType
        public void AddAsync(FarmKoiType newFarm)
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
        public void UpdateAsync(FarmKoiType farmKoiType)
        {
            if (farmKoiType == null)
            {
                throw new ArgumentNullException(nameof(farmKoiType), "FarmKoiType cannot be null.");
            }
            _farmKoiTypeRepository.UpdateFarm(farmKoiType);
        }

        // Delete a FarmKoiType
        public void DeleteAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "FarmKoiType cannot be null.");
            }
            _farmKoiTypeRepository.DeleteFarm(id);
        }
    }
}