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



        // Constructor to initialize the repository
        public FarmService( IFarmRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new Farm
        public async Task<bool> AddAsync(Farm newFarm)
        {
            if (newFarm == null)
            {
                throw new ArgumentNullException(nameof(newFarm), "Farm cannot be null.");
            }
            var check = await _repo.ReadAll();
            check = check.Where(c=>c.FarmName == newFarm.FarmName).ToList();
            if(check.Any()) 
            { 
                throw new Exception($"The name {newFarm.FarmName} had already been taken"); 
            }
            if(newFarm.EstablishedYear<1500 || newFarm.EstablishedYear > DateTime.UtcNow.Year)
            {
                throw new Exception($"The Established Year: {newFarm.EstablishedYear} is impossible to happen");
            }
            
            return await _repo.Add(newFarm);
        }

        // Retrieve all Farms
        public async Task<List<Farm>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a Farm by ID
        public async Task<Farm?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing Farm
        public async Task<bool> UpdateAsync(Farm update)
        {
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update), "Farm cannot be null.");
            }
            var check = await _repo.ReadAll();
            if (check.Any(c=>update.FarmName != c.FarmName && c.FarmName.ToLower().Equals(update.FarmName.ToLower())))
            {
                throw new Exception($"The name {update.FarmName} had already been taken");
            }
            if (update.EstablishedYear < 1700 || update.EstablishedYear > DateTime.UtcNow.Year)
            {
                throw new Exception($"The Established Year: {update.EstablishedYear} is impossible to happen");
            }
            return await _repo.Update(update);
        }

        // Delete a Farm
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