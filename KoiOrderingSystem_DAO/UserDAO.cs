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

    }
}

