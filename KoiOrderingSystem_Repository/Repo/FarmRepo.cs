using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository.Repo

{
    public class FarmRepo : BaseRepository<Farm>, IFarmRepo
    {
        public FarmRepo(KoiOrderingSystemContext context) : base(context)
        {
        }
    }
}
