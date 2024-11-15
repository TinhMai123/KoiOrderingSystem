using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_BusinessObject.ViewModels;
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
            return await _context.Kois.Include(k => k.KoiType).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Koi>> ReadAll()
        {
            return await _context.Kois.Include(k=>k.KoiType).AsNoTracking().ToListAsync();
        }
        public async Task<List<Koi>> GetAll()
        {
            return await _context.Kois.Include(k => k.KoiType).ToListAsync();
        }
        public async Task<KoiViewModel?> GetViewModelById(int id)
        {
            return await _context.Kois
            .Include(k => k.KoiType)
            .Include(k => k.Farm)
            .Select(k => new KoiViewModel
            {
                Koi = k,
                Price = _context.FarmKoiTypes
                    .Where(fkt => fkt.KoiTypeId == k.KoiTypeId && fkt.FarmId == k.FarmId)
                    .Select(fkt => fkt.Price)
                    .FirstOrDefault()
            }).SingleOrDefaultAsync(k => k.Koi.Id == id);
        }
        public async Task<List<KoiViewModel>> GetAllViewModel()
        {
            return await _context.Kois
            .Include(k => k.KoiType)
            .Include(k => k.Farm)
            .Select(k => new KoiViewModel
            {
                Koi = k,
                Price = _context.FarmKoiTypes
                    .Where(fkt => fkt.KoiTypeId == k.KoiTypeId && fkt.FarmId == k.FarmId)
                    .Select(fkt => fkt.Price)
                    .FirstOrDefault()
            })
            .ToListAsync();
        }
        public async Task<Koi?> ReadById(int id)
        {
            return await _context.Kois.Include(k => k.KoiType).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
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
                var existingModel = await _context.Kois.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.Kois.Remove(existingModel);
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
        public async Task<bool> Update(Koi model)
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
