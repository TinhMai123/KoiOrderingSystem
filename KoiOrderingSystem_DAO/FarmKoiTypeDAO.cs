using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<FarmKoiType>> GetAll()
        {
            return await _context.FarmKoiTypes.ToListAsync();
        }

        public async Task<FarmKoiType?> GetById(int id)
        {
            return await  _context.FarmKoiTypes.SingleOrDefaultAsync(x => x.Id == id) ;

        }
        public async Task<List<FarmKoiType>> ReadAll()
        {
            return await _context.FarmKoiTypes.AsNoTracking().ToListAsync();
        }

        public async Task<FarmKoiType?> ReadById(int id)
        {
            return await _context.FarmKoiTypes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        // CREATE a new FarmKoiType record
        public async Task<bool> Add(FarmKoiType model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.FarmKoiTypes.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.FarmKoiTypes.Add(model);
                    await _context.SaveChangesAsync();
                    _context.Entry(model).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }

        // UPDATE a FarmKoiType record
        public async Task<bool> Update(FarmKoiType model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.FarmKoiTypes.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _context.SaveChangesAsync();
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }

        // DELETE a FarmKoiType by its ID
        public async Task<bool> Remove(int id)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.FarmKoiTypes.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.FarmKoiTypes.Remove(existingModel);
                    await _context.SaveChangesAsync();
                    _context.Entry(existingModel).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }

        // Method for logging errors (placeholder for actual logging implementation)
        private void LogError(string message)
        {
            // Implement logging mechanism here (e.g., log to file, database, etc.)
            Console.WriteLine(message); // Placeholder
        }
    }
}
