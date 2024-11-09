using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IUserRepo
    {
        public Task<User?> GetUserByEmail(string email);
        Task<User?> GetById(int id);
        Task<List<User>> GetAll();
        Task<bool> Add(User model);
        Task<bool> Remove(int id);
        Task<bool> Update(User model);

    }
}
