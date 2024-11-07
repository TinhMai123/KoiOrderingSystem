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
            return await _context.Kois.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Koi>> GetAll()
        {
            return await _context.Kois.ToListAsync();
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
                    _context.SaveChanges();
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
                    _context.SaveChanges();
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
                    _context.SaveChanges();
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
