using System;
using System.Collections.Generic;
using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Repository.Repo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class KoiTypeService : IKoiTypeService
    {
        
        private readonly IBaseRepository<KoiType> _koiTypeRepository;


        // Constructor to initialize the repository
        public KoiTypeService(IBaseRepository<KoiType> koiTypeRepository)
        {
            _koiTypeRepository = koiTypeRepository;
        }

        // Add a new KoiType
        public async Task<bool> AddAsync(KoiType koiType)
        {
            if (koiType == null)
            {
                throw new ArgumentNullException(nameof(koiType), "KoiType cannot be null.");
            }
            return await _koiTypeRepository.AddAsync(koiType);
        }

        // Retrieve all KoiType records
        public async Task<List<KoiType>> GetAlls()
        {
            return await _koiTypeRepository.GetAllAsync();
        }

        // Retrieve a KoiType by ID
        public async Task<KoiType?> GetById(int id)
        {
            return await _koiTypeRepository.GetByIdAsync(id);
        }

        // Update an existing KoiType
        public async Task<bool> UpdateAsync(KoiType koiType)
        {
            if (koiType == null)
            {
                throw new ArgumentNullException(nameof(koiType), "KoiType cannot be null.");
            }
            return await _koiTypeRepository.UpdateAsync(koiType);
        }

        // Delete a KoiType by ID
        public async Task<bool> DeleteAsync(int id)
        {
            return await _koiTypeRepository.DeleteAsync(id);
        }

        

        

       

        
    }
}