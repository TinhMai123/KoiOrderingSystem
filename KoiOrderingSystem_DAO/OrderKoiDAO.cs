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
        public async Task<OrderKoi?> GetById(int id)
        {
            return await _context.OrderKois.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<OrderKoi>> GetAll()
        {
            return await _context.OrderKois.AsNoTracking().ToListAsync();
        }
        public async Task<OrderKoi?> ReadById(int id)
        {
            return await _context.OrderKois.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<bool> Add(OrderKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.OrderKois.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.OrderKois.Add(model);
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
        public async Task<bool> Remove(OrderKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.OrderKois.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.OrderKois.Remove(existingModel);
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
        public async Task<bool> Update(OrderKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.OrderKois.SingleOrDefaultAsync(x => x.Id == model.Id);
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
