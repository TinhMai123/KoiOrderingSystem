using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class KoiTypeDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiTypeDAO? instance = null;

        public KoiTypeDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static KoiTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new KoiTypeDAO();
                }
                return instance;
            }
        }
    }
}
