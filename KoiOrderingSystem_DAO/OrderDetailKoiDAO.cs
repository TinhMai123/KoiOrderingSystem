using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderDetailKoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderDetailKoiDAO? instance = null;

        public OrderDetailKoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderDetailKoiDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderDetailKoiDAO();
                }
                return instance;
            }
        }
        public OrderDetailKoi? GetById(int id)
        {
            return _context.OrderDetailKois.SingleOrDefault(x => x.Id == id);
        }
        public List<OrderDetailKoi> GetAll()
        {
            return _context.OrderDetailKois.ToList();
        }
        public bool Add(OrderDetailKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderDetailKois.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.OrderDetailKois.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(OrderDetailKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderDetailKois.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.OrderDetailKois.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(OrderDetailKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderDetailKois.SingleOrDefault(x => x.Id == model.Id);
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
