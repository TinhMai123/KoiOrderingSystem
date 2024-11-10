using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Repository.Repo;
using KoiOrderingSystem_Service.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KoiOrderingSystem_Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddAsync(User add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "User cannot be null.");
            }
            return await _repo.Add(add);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        public async Task<List<User>> GetAlls()
        {
            return await _repo.GetAll();
        }

        public async Task<User?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _repo.GetUserByEmail(email);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _repo.GetAll();
        }

        public async Task<bool> UpdateAsync(User update)
        {
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update), "Quote cannot be null.");
            }
            return await _repo.Update(update);
        }

    }
}
