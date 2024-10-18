using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class CurrencyDAO
    {
        private KoiOrderingSystemContext _context;
        private static CurrencyDAO? instance = null;

        public CurrencyDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static CurrencyDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new CurrencyDAO();
                }
                return instance;
            }
        }


    }
}
