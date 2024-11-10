
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.Repo
{
    public class UserRepo : IUserRepo
    {
        public async Task<bool> Add(User model)
        {
            return await UserDAO.Instance.Add(model);
        }

        public async Task<List<User>> GetAll()
        {
            return await UserDAO.Instance.GetUsers();
        }

        public async Task<User?> GetById(int id)
        {
            return await UserDAO.Instance.GetById(id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await UserDAO.Instance.GetUserByEmail(email);
        }

        public async Task<List<User>> ReadAll()
        {
            return await UserDAO.Instance.ReadUsers();
        }

        public async Task<User?> ReadById(int id)
        {
            return await UserDAO.Instance.ReadById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await UserDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(User model)
        {
            return await UserDAO.Instance.Update(model);
        }
    }

}
