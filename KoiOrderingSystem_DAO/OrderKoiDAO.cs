using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderKoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderKoiDAO? instance = null;

        public OrderKoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderKoiDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderKoiDAO();
                }
                return instance;
            }
        }
        public OrderKoi? GetById(int id)
        {
            return _context.OrderKois.SingleOrDefault(x => x.Id == id);
        }
        public List<OrderKoi> GetAll()
        {
            return _context.OrderKois.ToList();
        }
        public bool Add(OrderKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderKois.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.OrderKois.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(OrderKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderKois.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.OrderKois.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(OrderKoi model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderKois.SingleOrDefault(x => x.Id == model.Id);
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
