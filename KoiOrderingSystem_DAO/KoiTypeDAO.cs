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
    public class KoiTypeDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiTypeDAO? instance = null;

        public KoiTypeDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static KoiTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new KoiTypeDAO();
                }
                return instance;
            }
        }
        public async Task<KoiType?> GetById(int id)
        {
            return await _context.KoiTypes.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<KoiType>> GetAll()
        {
            return await _context.KoiTypes.AsNoTracking().ToListAsync();
        }
        public async Task<KoiType?> GetByIdNoTracking(int id)
        {
            return await _context.KoiTypes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Add(KoiType model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.KoiTypes.SingleOrDefaultAsync(x => x.Name == model.Name);
                if (existingModel == null)
                {
                    _context.KoiTypes.Add(model);
                    await _context.SaveChangesAsync();
                    _context.Entry(model).State = EntityState.Detached;
                    isSuccess = true;
                }
            } catch (Exception)
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
                var existingModel = await _context.KoiTypes.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.KoiTypes.Remove(existingModel);
                    await _context.SaveChangesAsync();
                    _context.Entry(existingModel).State = EntityState.Detached;
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public async Task<bool> Update(KoiType model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.KoiTypes.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _context.SaveChangesAsync();
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
    }
}
