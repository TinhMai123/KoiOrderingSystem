using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class FarmDAO
    {
        private KoiOrderingSystemContext _context;
        private static FarmDAO? instance = null;

        public FarmDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static FarmDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new FarmDAO();
                }
                return instance;
            }
        }
    }
}
