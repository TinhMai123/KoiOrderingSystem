using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderDAO? instance = null;

        public OrderDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderDAO();
                }
                return instance;
            }
        }
        public async Task<Order?> GetById(int id)
        {
            return await _context.Orders.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Order?> ReadById(int id)
        {
            return await _context.Orders.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Add(Order model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Orders.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Orders.Add(model);
                    await _context.SaveChangesAsync();
                    isSuccess = true;
                    _context.Entry(model).State = EntityState.Detached;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public async Task<bool> Remove(Order model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Orders.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Orders.Remove(existingModel);
                    await _context.SaveChangesAsync();
                    isSuccess = true;
                    _context.Entry(existingModel).State = EntityState.Detached;
                }
                
            } catch (Exception)
            {

                throw;
            }
            
            return isSuccess;
        }
        public async Task<bool> Update(Order model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Orders.SingleOrDefaultAsync(x => x.Id == model.Id);
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
