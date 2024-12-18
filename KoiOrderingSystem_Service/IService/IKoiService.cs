﻿using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service.IService
{
    public interface IKoiService
    {
        Task<bool> AddAsync(Koi add);
        Task<List<Koi>> GetAlls();
        Task<Koi?> GetById(int id);
        Task<List<KoiViewModel>> GetAllViewModel();
        Task<KoiViewModel?> GetViewModelById(int id);
        Task<List<Koi>> ReadAlls();
        Task<Koi?> ReadById(int id);
        Task<bool> UpdateAsync(Koi update);
        Task<bool> DeleteAsync(int id);
    }
}
