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
    public class OrderDetailKoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderDetailKoiDAO? instance = null;

        public OrderDetailKoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderDetailKoiDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderDetailKoiDAO();
                }
                return instance;
            }
        }
        public async Task<KoiOrderDetail?> GetById(int id)
        {
            return await _context.KoiOrderDetails.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<KoiOrderDetail>> ReadAll()
        {
            return await _context.KoiOrderDetails.AsNoTracking().ToListAsync();
        }
        public async Task<KoiOrderDetail?> ReadById(int id)
        {
            return await _context.KoiOrderDetails.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<KoiOrderDetail>> GetAll()
        {
            return await _context.KoiOrderDetails.ToListAsync();
        }
        public async Task<bool> Add(KoiOrderDetail model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.KoiOrderDetails.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.KoiOrderDetails.Add(model);
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
                var existingModel = await _context.KoiOrderDetails.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.KoiOrderDetails.Remove(existingModel);
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
        public async Task<bool> Update(KoiOrderDetail model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.KoiOrderDetails.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    existingModel.UpdatedAt = DateTime.Now;
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
