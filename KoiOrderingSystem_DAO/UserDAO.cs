using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class UserDAO
    {
        private KoiOrderingSystemContext _context;
        private static UserDAO? instance = null;

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new UserDAO();
                }
                return instance;
            }
        }
        public UserDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email.Equals(email));
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User? GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public bool Add(User model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Users.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Users.Add(model);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Remove(User model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Users.SingleOrDefault(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Users.Remove(existingModel);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public bool Update(User model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = _context.Users.SingleOrDefault(x => x.Id == model.Id);
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

