using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class KoiByBatchDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiByBatchDAO? instance = null;

        public KoiByBatchDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static KoiByBatchDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new KoiByBatchDAO();
                }
                return instance;
            }
        }
    }
}
