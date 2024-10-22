using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class KoiByBatchDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiByBatchDAO? instance = null;

        public KoiByBatchDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static KoiByBatchDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new KoiByBatchDAO();
                }
                return instance;
            }
        }
        public KoiByBatch? GetById(int id)
        {
            return _context.KoiByBatches.SingleOrDefault(x => x.Id == id);
        }
        public List<KoiByBatch> GetAll()
        {
            return _context.KoiByBatches.ToList();
        }
        public bool Add(KoiByBatch model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.KoiByBatches.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.KoiByBatches.Add(model);
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
        public bool Remove(KoiByBatch model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.KoiByBatches.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.KoiByBatches.Remove(existingModel);
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
        public bool Update(KoiByBatch model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.KoiByBatches.SingleOrDefault(x => x.Id == model.Id);
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
