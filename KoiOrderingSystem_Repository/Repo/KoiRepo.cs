﻿
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository.Repo

{
    public class KoiRepo : IKoiRepo
    {
        public async Task<bool> Add(Koi model)
        {
            return await KoiDAO.Instance.Add(model);
        }

        public async Task<List<Koi>> GetAll()
        {
            return await KoiDAO.Instance.GetAll();
        }

        public async Task<Koi?> GetById(int id)
        {
            return await KoiDAO.Instance.GetById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await KoiDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(Koi model)
        {
            return await KoiDAO.Instance.Update(model);
        }
    }
}
