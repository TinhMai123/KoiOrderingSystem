using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class FarmKoiTypeDAO
    {
        private KoiOrderingSystemContext _context;
        private static FarmKoiTypeDAO? instance = null;

        public FarmKoiTypeDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static FarmKoiTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new FarmKoiTypeDAO();
                }
                return instance;
            }
        }
    }
}
