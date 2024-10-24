﻿using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository.Repo

{
    public class KoiRepo : BaseRepository<Koi>, IKoiRepo
    {
        public KoiRepo(KoiOrderingSystemContext context) : base(context)
        {
        }
    }
}
