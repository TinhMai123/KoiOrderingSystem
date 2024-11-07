using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<User>> ReadUsers()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }
        public async Task<User?> ReadById(int id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Add(User model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Users.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel == null)
                {
                    _context.Users.Add(model);
                    await _context.SaveChangesAsync();
                    _context.Entry(model).State = EntityState.Detached;
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public async Task<bool> Remove(User model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Users.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Users.Remove(existingModel);
                    _context.SaveChanges();
                    _context.Entry(model).State = EntityState.Detached;
                    isSuccess = true;
                }
            } catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
        public async Task<bool> Update(User model)
        {
            var isSuccess = false;
            try
            {
                var existingModel = await _context.Users.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existingModel != null)
                {
                    _context.Remove(existingModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _context.SaveChangesAsync();
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

