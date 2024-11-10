using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.IRepo
{
    public interface IFeedbackRepo
    {
        Task<Feedback?> GetById(int id);
        Task<List<Feedback>> GetAll();
        Task<bool> Add(Feedback model);
        Task<bool> Remove(int id);
        Task<bool> Update(Feedback model);
        Task<Feedback?> ReadById(int id);
        Task<List<Feedback>> ReadAll();
    }
}
