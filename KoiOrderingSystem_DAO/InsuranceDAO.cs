using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class InsuranceDAO
    {
        private KoiOrderingSystemContext _context;
        private static InsuranceDAO? instance = null;

        public InsuranceDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static InsuranceDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new InsuranceDAO();
                }
                return instance;
            }
        }
    }
}
