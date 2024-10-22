using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
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
        public Quote? GetById(int id)
        {
            return _context.Quotes.SingleOrDefault(x => x.Id == id);
        }
        public List<Quote> GetAll()
        {
            return _context.Quotes.ToList();
        }
        public bool Add(Quote model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Quotes.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Quotes.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(Quote model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Quotes.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Quotes.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(Quote model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Quotes.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
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
