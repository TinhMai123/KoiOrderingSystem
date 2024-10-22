using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class CurrencyDAO
    {
        private KoiOrderingSystemContext _context;
        private static CurrencyDAO? instance = null;

        public CurrencyDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static CurrencyDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new CurrencyDAO();
                }
                return instance;
            }
        }

        public Currency? GetById(int id)
        {
            return _context.Currencies.SingleOrDefault(x => x.Id == id);
        }
        public List<Currency> GetAll()
        {
            return _context.Currencies.ToList();
        }
        public bool Add(Currency model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Currencies.SingleOrDefault(x => x.Name == model.Name);
                if (existingModel == null)
                {
                    _context.Currencies.Add(model);
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
        public bool Remove(Currency model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Currencies.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Currencies.Remove(existingModel);
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
        public bool Update(Currency model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Currencies.SingleOrDefault(x => x.Id == model.Id);
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
