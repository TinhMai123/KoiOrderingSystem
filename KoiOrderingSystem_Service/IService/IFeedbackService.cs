using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IFeedbackService
    {
        Task<bool> AddAsync(Feedback add);
        Task<List<Feedback>> GetAlls();
        Task<Feedback?> GetById(int id);
        Task<bool> UpdateAsync(Feedback update);
        Task<bool> DeleteAsync(int id);
    }
}
