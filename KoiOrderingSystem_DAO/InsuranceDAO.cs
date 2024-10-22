using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
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
        public Insurance? GetById(int id)
        {
            return _context.Insurances.SingleOrDefault(x => x.Id == id);
        }
        public List<Insurance> GetAll()
        {
            return _context.Insurances.ToList();
        }
        public bool Add(Insurance model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Insurances.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Insurances.Add(model);
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
        public bool Remove(Insurance model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Insurances.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Insurances.Remove(existingModel);
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
        public bool Update(Insurance model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Insurances.SingleOrDefault(x => x.Id == model.Id);
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
