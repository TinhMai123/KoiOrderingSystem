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
    public class InsuranceDAO
    {
        private KoiOrderingSystemContext _context;
        private static InsuranceDAO? instance = null;

        public InsuranceDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static InsuranceDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new InsuranceDAO();
                }
                return instance;
            }
        }
        public async Task<Insurance?> GetById(int id)
        {
            return await _context.Insurances.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Insurance>> GetAll()
        {
            return await _context.Insurances.ToListAsync();
        }
        public async Task<Insurance?> ReadById(int id)
        {
            return await _context.Insurances.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Insurance>> ReadAll()
        {
            return await _context.Insurances.AsNoTracking().ToListAsync();
        }
        public async  Task<bool> Add(Insurance model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await  _context.Insurances.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Insurances.Add(model);
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
                var existingModel = await _context.Insurances.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.Insurances.Remove(existingModel);
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
        public async Task<bool> Update(Insurance model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Insurances.SingleOrDefaultAsync(x => x.Id == model.Id);
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
