using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
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
        public Feedback? GetById(int id)
        {
            return _context.Feedbacks.SingleOrDefault(x => x.Id == id);
        }
        public List<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }
        public bool Add(Feedback model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Feedbacks.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Feedbacks.Add(model);
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
        public bool Remove(Feedback model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Feedbacks.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Feedbacks.Remove(existingModel);
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
        public bool Update(Feedback model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Feedbacks.SingleOrDefault(x => x.Id == model.Id);
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
