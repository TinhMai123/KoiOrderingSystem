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
        public User? GetUserByEmail(string email);
        public List<User> GetUsers();
    }
}
