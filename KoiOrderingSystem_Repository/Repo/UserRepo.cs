using KoiOrderingSystem_BusinessObject;
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
        public User? GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);
        public List<User> GetUsers() => UserDAO.Instance.GetUsers();
    }
}
