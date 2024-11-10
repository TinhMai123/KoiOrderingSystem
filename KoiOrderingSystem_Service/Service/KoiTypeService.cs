using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Repository.Repo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class KoiTypeService : IKoiTypeService
    {
        
        private readonly IKoiTypeRepo _repo;



        // Constructor to initialize the repository
        public KoiTypeService( IKoiTypeRepo repo)
        {
            _repo = repo;
        }

        // Add a new KoiType
        public async Task<bool> AddAsync(KoiType koiType)
        {
            if (koiType == null)
            {
                throw new ArgumentNullException(nameof(koiType), "KoiType cannot be null.");
            }
            var check = await _repo.ReadAll();
            if (check.Any(c=>c.Name.ToLower().Equals(koiType.Name.ToLower())))
            {
                throw new Exception($"This name {koiType.Name} had already been taken");
            }
            return await _repo.Add(koiType);
        }

        // Retrieve all KoiType records
        public async Task<List<KoiType>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a KoiType by ID
        public async Task<KoiType?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing KoiType
        public async Task<bool> UpdateAsync(KoiType koiType)
        {
            if (koiType == null)
            {
                throw new ArgumentNullException(nameof(koiType), "KoiType cannot be null.");
            }
            var check = await _repo.ReadAll();
            if (check.Any(c => c.Name.ToLower().Equals(koiType.Name.ToLower()) && c.Name != koiType.Name))
            {
                throw new Exception($"This name {koiType.Name} had already been taken");
            }
            return await _repo.Update(koiType);
        }

        // Delete a KoiType by ID
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        

        

       

        
    }
}