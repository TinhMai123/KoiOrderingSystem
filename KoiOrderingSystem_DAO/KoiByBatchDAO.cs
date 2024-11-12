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
    public class KoiByBatchDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiByBatchDAO? instance = null;

        public KoiByBatchDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static KoiByBatchDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new KoiByBatchDAO();
                }
                return instance;
            }
        }
        public async Task<KoiByBatch?> GetById(int id)
        {
            return await _context.KoiByBatches.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<KoiByBatch>> GetAll()
        {
            return await _context.KoiByBatches.ToListAsync();
        }
        public async Task<KoiByBatch?> ReadById(int id)
        {
            return await _context.KoiByBatches.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<KoiByBatch>> ReadAll()
        {
            return await _context.KoiByBatches.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Add(KoiByBatch model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.KoiByBatches.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.KoiByBatches.Add(model);
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
                var existingModel = await _context.KoiByBatches.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.KoiByBatches.Remove(existingModel);
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
        public async Task<bool> Update(KoiByBatch model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.KoiByBatches.SingleOrDefaultAsync(x => x.Id == model.Id);
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
