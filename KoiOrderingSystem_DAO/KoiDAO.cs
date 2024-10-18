using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class KoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static KoiDAO? instance = null;

        public KoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static KoiDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new KoiDAO();
                }
                return instance;
            }
        }
    }
}
