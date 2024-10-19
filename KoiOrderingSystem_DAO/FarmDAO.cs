using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class FarmDAO
    {
        private KoiOrderingSystemContext _context;
        private static FarmDAO? instance = null;

        public FarmDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static FarmDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new FarmDAO();
                }
                return instance;
            }
        }
        public Farm? GetById(int id)
        {
            return _context.Farms.SingleOrDefault(x => x.Id == id);
        }
        public List<Farm> GetAll()
        {
            return _context.Farms.ToList();
        }
        public bool Add(Farm model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Farms.SingleOrDefault(x => x.FarmName == model.FarmName);
                if (existingModel == null)
                {
                    _context.Farms.Add(model);
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
        public bool Remove(Farm model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Farms.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Farms.Remove(existingModel);
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
        public bool Update(Farm model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Farms.SingleOrDefault(x => x.Id == model.Id);
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
