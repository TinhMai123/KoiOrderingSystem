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
    public class FarmDAO
    {
        private KoiOrderingSystemContext _context;
        private static FarmDAO? instance = null;

        public FarmDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

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
        public async Task<Farm?> GetById(int id)
        {
            return await _context.Farms.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Farm>> GetAll()
        {
            return await _context.Farms.ToListAsync();
        }
        public async Task<Farm?> ReadById(int id)
        {
            return await _context.Farms.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Farm>> ReadAll()
        {
            return await _context.Farms.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Add(Farm model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Farms.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Farms.Add(model);
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
        public async Task<bool> Remove(Farm model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Farms.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Farms.Remove(existingModel);
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
        public async Task<bool> Update(Farm model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Farms.SingleOrDefaultAsync(x => x.Id == model.Id);
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
    }
}
