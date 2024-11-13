using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepo _repo;

        public FarmService(IFarmRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<bool> AddAsync(Farm newFarm)
        {
            if (newFarm == null)
            {
                throw new ArgumentNullException(nameof(newFarm), "Farm cannot be null.");
            }

            return await _repo.Add(newFarm);
        }

        public async Task<List<Farm>> GetAlls()
        {
            return await _repo.GetAll();
        }

        public async Task<Farm?> GetById(int id)
        {
            return await _repo.GetById(id);
        }
        public async Task<bool> UpdateAsync(Farm update)
        {
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update), "Farm cannot be null.");
            }

            return await _repo.Update(update);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        public async Task<List<Farm>> ReadAlls()
        {
            return await _repo.ReadAll();
        }

        public async Task<Farm?> ReadById(int id)
        {
            return await _repo.ReadById(id);
        }
    }
}
