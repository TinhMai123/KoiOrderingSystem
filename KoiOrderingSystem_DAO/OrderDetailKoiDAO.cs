using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderDetailKoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderDetailKoiDAO? instance = null;

        public OrderDetailKoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderDetailKoiDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderDetailKoiDAO();
                }
                return instance;
            }
        }
    }
}
