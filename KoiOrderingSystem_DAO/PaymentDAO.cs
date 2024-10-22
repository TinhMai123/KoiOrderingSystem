using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class PaymentDAO
    {
        private KoiOrderingSystemContext _context;
        private static PaymentDAO? instance = null;

        public PaymentDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new PaymentDAO();
                }
                return instance;
            }
        }
        public Payment? GetById(int id)
        {
            return _context.Payments.SingleOrDefault(x => x.Id == id);
        }
        public List<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }
        public bool Add(Payment model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Payments.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Payments.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(Payment model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Payments.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Payments.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(Payment model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Payments.SingleOrDefault(x => x.Id == model.Id);
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
