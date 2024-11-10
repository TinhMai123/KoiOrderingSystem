using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IUserService
    {
        Task<User?>  GetUserByEmail(string email);
        Task<bool> AddAsync(User add);
        Task<List<User>> GetAlls();
        Task<User?> GetById(int id);
        Task<bool> UpdateAsync(User update);
        Task<bool> DeleteAsync(int id);
    }
}
