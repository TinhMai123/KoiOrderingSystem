using System;
using System.Collections.Generic;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepo _repo;


        // Constructor to initialize the repository
        public KoiService(IKoiRepo repo)
        {
            _repo = repo;
        }

        // Add a new Koi
        public async Task<bool> AddAsync(Koi koi)
        {
            if (koi == null)
            {
                throw new ArgumentNullException(nameof(koi), "Koi cannot be null.");
            }
            if (koi.Weight <= 0)
            {
                throw new Exception("A Koi cannot have a weight of 0 or smaller");
            }
            if(koi.Price < 0) 
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            if(koi.BirthDate> DateTime.UtcNow || koi.BirthDate?.Year - 300 < 0)
            {
                throw new Exception("A Koi Fish cannot have a Birth Date like that");
            }
            if (koi.DateAdded > DateTime.UtcNow || koi.DateAdded.Year - 300 < 0)
            {
                throw new Exception("A Koi Fish cannot have a Date like that");
            }
            return await _repo.Add(koi);
        }
        public async Task<List<Koi>> GetAlls()
        {
            return await _repo.GetAll();
        }
        // Remove an existing Koi
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        // Get a Koi by its ID
        public async Task<Koi?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing Koi
        public async Task<bool> UpdateAsync(Koi update)
        {
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update), "koi cannot be null.");
            }
            if (update.Weight <= 0)
            {
                throw new Exception("A Koi cannot have a weight of 0 or smaller");
            }
            if (update.Price < 0)
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            if (update.BirthDate > DateTime.UtcNow || update.BirthDate?.Year - 300 < 0)
            {
                throw new Exception("A Koi Fish cannot have a Birth Date like that");
            }
            if (update.DateAdded > DateTime.UtcNow || update.DateAdded.Year - 300 < 0)
            {
                throw new Exception("A Koi Fish cannot have a Date like that");
            }
            return await _repo.Update(update);
        }

        public async Task<List<Koi>> ReadAlls()
        {
            return await _repo.ReadAll();
        }

        public async Task<Koi?> ReadById(int id)
        {
            return await _repo.ReadById(id);
        }
    }
}