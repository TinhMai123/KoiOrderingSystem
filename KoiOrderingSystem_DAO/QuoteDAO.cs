using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class QuoteDAO
    {
        private KoiOrderingSystemContext _context;
        private static QuoteDAO? instance = null;
        public QuoteDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static QuoteDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new QuoteDAO();
                }
                return instance;
            }
        }
    }
}
