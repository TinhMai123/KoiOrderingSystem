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
    public class CurrencyDAO
    {
        private KoiOrderingSystemContext _context;
        private static CurrencyDAO? instance = null;

        public CurrencyDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static CurrencyDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new CurrencyDAO();
                }
                return instance;
            }
        }

        public async Task<Currency?> GetById(int id)
        {
            return await _context.Currencies.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Currency>> GetAll()
        {
            return await _context.Currencies.ToListAsync();
        }
        public async Task<Currency?> RedById(int id)
        {
            return await _context.Currencies.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Currency>> ReadAll()
        {
            return await _context.Currencies.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Add(Currency model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Currencies.SingleOrDefaultAsync(x => x.Name == model.Name);
                if (existingModel == null)
                {
                    _context.Currencies.Add(model);
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
        public async Task<bool> Remove(Currency model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Currencies.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Currencies.Remove(existingModel);
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
        public async Task<bool> Update(Currency model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Currencies.SingleOrDefaultAsync(x => x.Id == model.Id);
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
