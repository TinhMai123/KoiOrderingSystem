using ClassBookingRoom_Repository;
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.Repo
{
    public class CurrencyRepo : BaseRepository<Currency>, ICurrencyRepo
    {
        public CurrencyRepo(KoiOrderingSystemContext context) : base(context)
        {
        }
    }
}
