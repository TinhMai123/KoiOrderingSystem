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
    public class KoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiDAO? instance = null;

        public KoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

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
        public async Task<Koi?> GetById(int id)
        {
            return await _context.Kois.Include(k => k.KoiType).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Koi>> ReadAll()
        {
            return await _context.Kois.AsNoTracking().ToListAsync();
        }
        public async Task<List<Koi>> GetAll()
        {
            return await _context.Kois.Include(k => k.KoiType).ToListAsync();
        }
        public async Task<Koi?> ReadById(int id)
        {
            return await _context.Kois.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Add(Koi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Kois.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Kois.Add(model);
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
        public async Task<bool> Remove(int id)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Kois.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.Kois.Remove(existingModel);
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
        public async Task<bool> Update(Koi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Kois.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    existingModel.UpdatedAt = DateTime.Now;
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
