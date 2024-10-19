using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KoiOrderingSystem_DAO
{
    public class KoiDAO
    {
        
        private static KoiDAO instance;
        private static KoiOrderingSystemContext dbcontext;

        // Private constructor to prevent direct instantiation
        private KoiDAO()
        {
            dbcontext = new KoiOrderingSystemContext();
        }

        // Public property to access the singleton instance
        public static KoiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiDAO();
                }
                return instance;
            }
        }

        // Method to get all Koi records
        public List<Koi> GetAllKoi()
        {
            try
            {
                return dbcontext.Kois.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Koi list: {ex.Message}");
                return new List<Koi>();
            }
        }

        // Method to get a Koi by its ID
        public Koi GetKoiById(int koiId)
        {
            try
            {
                return dbcontext.Kois.SingleOrDefault(e => e.Id == koiId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Koi by ID: {ex.Message}");
                return null;
            }
        }

        // Method to add a new Koi
        public bool AddKoi(Koi newKoi)
        {
            bool added = false;
            try
            {
                if (GetKoiById(newKoi.Id) == null)
                {
                    dbcontext.Kois.Add(newKoi);
                    dbcontext.SaveChanges();
                    added = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding new Koi: {ex.Message}");
                throw new Exception(ex.Message);
            }
            return added;
        }

        // Method to remove a Koi
        public bool RemoveKoi(Koi koi)
        {
            bool removed = false;
            try
            {
                if (koi != null)
                {
                    dbcontext.Kois.Remove(koi);
                    dbcontext.SaveChanges();
                    removed = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing Koi: {ex.Message}");
                throw new Exception(ex.Message);
            }
            return removed;
        }

        // Method to update a Koi
        public bool UpdateKoi(Koi koi)
        {
            bool updated = false;
            try
            {
                if (koi != null)
                {
                    dbcontext.Kois.Update(koi);
                    dbcontext.SaveChanges();
                    updated = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Koi: {ex.Message}");
                throw new Exception(ex.Message);
            }
            return updated;
        }
    }
}
