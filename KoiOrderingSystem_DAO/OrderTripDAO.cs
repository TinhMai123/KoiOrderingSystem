using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderTripDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderTripDAO? instance = null;

        public OrderTripDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderTripDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderTripDAO();
                }
                return instance;
            }
        }
        public OrderTrip? GetById(int id)
        {
            return _context.OrderTrips.SingleOrDefault(x => x.Id == id);
        }
        public List<OrderTrip> GetAll()
        {
            return _context.OrderTrips.ToList();
        }
        public bool Add(OrderTrip model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderTrips.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.OrderTrips.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(OrderTrip model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderTrips.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.OrderTrips.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(OrderTrip model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.OrderTrips.SingleOrDefault(x => x.Id == model.Id);
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
