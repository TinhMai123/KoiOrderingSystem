using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiOrderingSystem_DAO
{
    public class FarmDAO
    {
        // Singleton instance
        private static FarmDAO instance;
        private readonly KoiOrderingSystemContext _context;

        // Private constructor to prevent direct instantiation
        private FarmDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        // Public property to access the singleton instance
        public static FarmDAO Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (instance == null)
                {
                   instance = new FarmDAO();
                }
                return instance;
            }
        }

        // CREATE a new Farm record
        public void AddFarm(Farm newFarm)
        {
            try
            {
                _context.Farms.Add(newFarm); // Make sure Farms is a valid DbSet in your DbContext
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding farm: {ex.Message}");
            }
        }

        // READ all Farm records
        public List<Farm> GetAllFarms()
        {
            return _context.Farms.ToList();
        }

        // READ a Farm by its ID
        public Farm GetFarmById(int id)
        {
            return _context.Farms.Find(id); // Use Find method for primary key lookup
        }

        // UPDATE a Farm record
        public void UpdateFarm(Farm farmToUpdate)
        {
            try
            {
                _context.Farms.Update(farmToUpdate); // Mark entity as updated
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating farm: {ex.Message}");
            }
        }

        // DELETE a Farm by its ID
        public void DeleteFarm(Farm farmToDelete)
        {
            try
            {
            
                if (farmToDelete != null)
                {
                    _context.Farms.Remove(farmToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting farm: {ex.Message}");
            }
        }
    }
}
