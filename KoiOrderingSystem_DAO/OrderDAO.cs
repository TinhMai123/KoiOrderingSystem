using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderDAO? instance = null;

        public OrderDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderDAO();
                }
                return instance;
            }
        }
    }
}
