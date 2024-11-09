using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IOrderRepo
    {
        Task<Order?> GetById(int id);
        Task<List<Order>> GetAll();
        Task<bool> Add(Order model);
        Task<bool> Remove(int id);
        Task<bool> Update(Order model);
        Task<Order?> ReadById(int id);
        Task<List<Order>> ReadAll();
    }
}
