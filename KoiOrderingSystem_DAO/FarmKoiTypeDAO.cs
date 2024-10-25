using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class FarmKoiTypeDAO
    {
        private readonly KoiOrderingSystemContext _context;
        // Singleton instance with thread safety
        private static FarmKoiTypeDAO? _instance = null;
        // Constructor to initialize the database context
        public FarmKoiTypeDAO()
        {
            _context = new KoiOrderingSystemContext();
        }


        public static FarmKoiTypeDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FarmKoiTypeDAO();
                }
                return _instance;
            }
        } 

        // CREATE a new FarmKoiType record
        public void AddFarmKoiType(FarmKoiType newFarmKoiType)
        {
            try
            {
                _context.FarmKoiTypes.Add(newFarmKoiType);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError($"Error adding FarmKoiType: {ex.Message}");
            }
        }

        // READ all FarmKoiType records
        public List<FarmKoiType> GetAllFarmKoiTypes()
        {
            return _context.FarmKoiTypes.ToList();
        }

        // READ a FarmKoiType by its ID
        public FarmKoiType GetFarmKoiTypeById(int id)
        {
            return _context.FarmKoiTypes.Find(id);
        }

        // UPDATE a FarmKoiType record
        public void UpdateFarmKoiType(FarmKoiType farmKoiTypeToUpdate)
        {
            try
            {
                _context.FarmKoiTypes.Update(farmKoiTypeToUpdate);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                LogError($"Error updating FarmKoiType: {ex.Message}");
            }
        }

        // DELETE a FarmKoiType by its ID
        public void DeleteFarmKoiType(FarmKoiType farmKoiTypeToDelete)
        {
            try
            {
                
                if (farmKoiTypeToDelete != null)
                {
                    _context.FarmKoiTypes.Remove(farmKoiTypeToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogError($"Error deleting FarmKoiType: {ex.Message}");
            }
        }

        // Method for logging errors (placeholder for actual logging implementation)
        private void LogError(string message)
        {
            // Implement logging mechanism here (e.g., log to file, database, etc.)
            Console.WriteLine(message); // Placeholder
        }
    }
}
