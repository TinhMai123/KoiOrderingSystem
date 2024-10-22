using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderDAO? instance = null;

        public OrderDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderDAO();
                }
                return instance;
            }
        }
        public Order? GetById(int id)
        {
            return _context.Orders.SingleOrDefault(x => x.Id == id);
        }
        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
        public bool Add(Order model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Orders.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Orders.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(Order model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Orders.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Orders.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(Order model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Orders.SingleOrDefault(x => x.Id == model.Id);
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
