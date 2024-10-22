using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class KoiTypeDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiTypeDAO? instance = null;

        public KoiTypeDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static KoiTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new KoiTypeDAO();
                }
                return instance;
            }
        }
        public KoiType? GetById(int id)
        {
            return _context.KoiTypes.SingleOrDefault(x => x.Id == id);
        }
        public List<KoiType> GetAll()
        {
            return _context.KoiTypes.ToList();
        }
        public bool Add(KoiType model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.KoiTypes.SingleOrDefault(x => x.Name == model.Name);
                if (existingModel == null)
                {
                    _context.KoiTypes.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(KoiType model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.KoiTypes.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.KoiTypes.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(KoiType model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.KoiTypes.SingleOrDefault(x => x.Id == model.Id);
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
