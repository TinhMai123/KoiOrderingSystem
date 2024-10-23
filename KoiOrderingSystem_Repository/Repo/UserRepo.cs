using ClassBookingRoom_Repository;
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
        public User? GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);
        public List<User> GetUsers() => UserDAO.Instance.GetUsers();
    }
    //public class UserRepo : BaseRepository<User>, IUserRepo
    //{
    //    public UserRepo(KoiOrderingSystemContext context) : base(context)
    //    {
    //    }
    //    public User? GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);
    //    public List<User> GetUsers() => UserDAO.Instance.GetUsers();
    //}
}
