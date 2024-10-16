using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service
{
    public interface IUserService
    {
        public User? GetUserByEmail(string email);
        public List<User> GetUsers();
    }
}
