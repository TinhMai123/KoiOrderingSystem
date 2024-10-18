using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class OrderKoiDAO
    {
        private KoiOrderingSystemContext _context;
        private static OrderKoiDAO? instance = null;

        public OrderKoiDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static OrderKoiDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new OrderKoiDAO();
                }
                return instance;
            }
        }
    }
}
