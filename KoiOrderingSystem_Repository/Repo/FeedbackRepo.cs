
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystem_DAO;

namespace KoiOrderingSystem_Repository.Repo
{
    public class FeedbackRepo : IFeedbackRepo
    {
        public async Task<bool> Add(Feedback model)
        {
           return await FeedbackDAO.Instance.Add(model);
        }

        public async Task<List<Feedback>> GetAll()
        {
            return await FeedbackDAO.Instance.GetAll();
        }

        public async Task<Feedback?> GetById(int id)
        {
            return await FeedbackDAO.Instance.GetById(id);
        }

        public async Task<List<Feedback>> ReadAll()
        {
            return await FeedbackDAO.Instance.ReadAll();
        }

        public async Task<Feedback?> ReadById(int id)
        {
            return await FeedbackDAO.Instance.ReadById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await FeedbackDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Feedback model)
        {
            return await FeedbackDAO.Instance.Update(model);
        }
    }
}
