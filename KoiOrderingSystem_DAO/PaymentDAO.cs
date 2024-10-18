using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class PaymentDAO
    {
        private KoiOrderingSystemContext _context;
        private static PaymentDAO? instance = null;

        public PaymentDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new PaymentDAO();
                }
                return instance;
            }
        }
    }
}
