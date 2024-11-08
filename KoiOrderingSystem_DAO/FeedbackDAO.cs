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
    public class FeedbackDAO
    {
        private KoiOrderingSystemContext _context;
        private static FeedbackDAO? instance = null;

        public FeedbackDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new FeedbackDAO();
                }
                return instance;
            }
        }
        public async Task<Feedback?> GetById(int id)
        {
            return await _context.Feedbacks.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Feedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
        }
        public async Task<Feedback?> ReadById(int id)
        {
            return await _context.Feedbacks.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Feedback>> ReadAll()
        {
            return await _context.Feedbacks.AsNoTracking().ToListAsync();
        }
        public async Task<bool> Add(Feedback model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Feedbacks.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Feedbacks.Add(model);
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
        public async Task<bool> Remove(Feedback model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Feedbacks.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Feedbacks.Remove(existingModel);
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
        public async Task<bool> Update(Feedback model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Feedbacks.SingleOrDefaultAsync(x => x.Id == model.Id);
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
