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
    public class QuoteDAO
    {
        private KoiOrderingSystemContext _context;
        private static QuoteDAO? instance = null;
        public QuoteDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static QuoteDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new QuoteDAO();
                }
                return instance;
            }
        }
        public async Task<Quote?> GetById(int id)
        {
            return await _context.Quotes.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Quote>> GetAll()
        {
            return await _context.Quotes.ToListAsync();
        }
        public async Task<Quote?> ReadById(int id)
        {
            return await _context.Quotes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Quote>> ReadAll()
        {
            return await _context.Quotes.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Add(Quote model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Quotes.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Quotes.Add(model);
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
                var existingModel = await _context.Quotes.SingleOrDefaultAsync(x => x.Id == id);
                if (existingModel != null)
                {
                    _context.Quotes.Remove(existingModel);
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
        public async Task<bool> Update(Quote model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Quotes.SingleOrDefaultAsync(x => x.Id == model.Id);
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
