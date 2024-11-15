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
    public class OrderKoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderKoiDAO? instance = null;

        public OrderKoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderKoiDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderKoiDAO();
                }
                return instance;
            }
        }
        public async Task<KoiOrder?> GetById(int id)
        {
            return await _context.KoiOrders.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<KoiOrder>> ReadAll()
        {
            return await _context.KoiOrders.AsNoTracking().ToListAsync();
        }
        public async Task<KoiOrder?> ReadById(int id)
        {
            return await _context.KoiOrders.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<List<KoiOrder>> GetAll()
        {
            return await _context.KoiOrders.ToListAsync();
        }
        public async Task<bool> Add(KoiOrder model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.KoiOrders.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.KoiOrders.Add(model);
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
                var existingModel = await _context.KoiOrders.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.KoiOrders.Remove(existingModel);
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
        public async Task<bool> Update(KoiOrder model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await ReadById(model.Id);
                if (existingModel != null)
                {
                    model.UpdatedAt = DateTime.Now;
                    _context.Update(model);
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
    }
}
