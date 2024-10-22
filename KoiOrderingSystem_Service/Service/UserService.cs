using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Repository.Repo;
using KoiOrderingSystem_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.Service
{
    public class UserService : IUserService
    {
        private IUserRepo IUserRepo;


        public UserService()
        {
            IUserRepo = new UserRepo();
        }
        public User? GetUserByEmail(string email)
        {
            return IUserRepo.GetUserByEmail(email);
        }

        public List<User> GetUsers()
        {
            return IUserRepo.GetUsers();
        }
    }
}
