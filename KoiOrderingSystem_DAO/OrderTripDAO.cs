using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderTripDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderTripDAO? instance = null;

        public OrderTripDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderTripDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderTripDAO();
                }
                return instance;
            }
        }
    }
}
