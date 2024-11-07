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
        public async Task<OrderDetailKoi?> GetById(int id)
        {
            return await _context.OrderDetailKois.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<OrderDetailKoi>> ReadAll()
        {
            return await _context.OrderDetailKois.AsNoTracking().ToListAsync();
        }
        public async Task<OrderDetailKoi?> ReadById(int id)
        {
            return await _context.OrderDetailKois.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<OrderDetailKoi>> GetAll()
        {
            return await _context.OrderDetailKois.ToListAsync();
        }
        public async Task<bool> Add(OrderDetailKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.OrderDetailKois.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.OrderDetailKois.Add(model);
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
        public async Task<bool> Remove(OrderDetailKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderDetailKois.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.OrderDetailKois.Remove(model);
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
        public async Task<bool> Update(OrderDetailKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.OrderDetailKois.SingleOrDefaultAsync(x => x.Id == model.Id);
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
