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
    public class PaymentDAO
    {
        private KoiOrderingSystemContext _context;
        private static PaymentDAO? instance = null;

        public PaymentDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new PaymentDAO();
                }
                return instance;
            }
        }
        public async Task<Payment?> GetById(int id)
        {
            return await _context.Payments.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Payment>> GetAll()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<List<Payment>> ReadAll()
        {
            return await _context.Payments.AsNoTracking().ToListAsync();
        }
        public async Task<Payment?> ReadById(int id)
        {
            return await _context.Payments.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Add(Payment model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Payments.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Payments.Add(model);
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
        public async Task<bool> Remove(Payment model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Payments.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Payments.Remove(existingModel);
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
        public async Task<bool> Update(Payment model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Payments.SingleOrDefaultAsync(x => x.Id == model.Id);
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
