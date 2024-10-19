using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiOrderingSystem_DAO
{
    public class KoiTypeDAO
    {
        // Singleton instance
        private static KoiTypeDAO instance;
        private static readonly object lockObj = new object(); // For thread-safety
        private readonly KoiOrderingSystemContext _context;

        // Private constructor to prevent direct instantiation
        private KoiTypeDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        // Public property to access the singleton instance
        public static KoiTypeDAO Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (instance == null)
                {
                   instance = new KoiTypeDAO();
                }
                return instance;
            }
        }

        // CREATE a new KoiType record
        public void AddKoiType(KoiType newKoiType)
        {
            try
            {
                _context.KoiTypes.Add(newKoiType); // Make sure KoiTypes is a valid DbSet
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding KoiType: {ex.Message}");
            }
        }

        // READ all KoiType records
        public List<KoiType> GetAllKoiTypes()
        {
            return _context.KoiTypes.ToList();
        }

        // READ a KoiType by its ID
        public KoiType GetKoiTypeById(int id)
        {
            return _context.KoiTypes.Find(id); // Use Find for primary key
        }

        // UPDATE a KoiType record
        public void UpdateKoiType(KoiType koiTypeToUpdate)
        {
            try
            {
                _context.KoiTypes.Update(koiTypeToUpdate); // Update method to modify the existing record
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating KoiType: {ex.Message}");
            }
        }

        // DELETE a KoiType by its ID
        public void DeleteKoiType(KoiType koiTypeToDelete)
        {
            try
            {
           
                if (koiTypeToDelete != null)
                {
                    _context.KoiTypes.Remove(koiTypeToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting KoiType: {ex.Message}");
            }
        }
    }
}
