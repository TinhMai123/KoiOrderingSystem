using KoiOrderingSystem_BusinessObject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_DAO
{
    public class FeedbackDAO
    {
        private KoiOrderingSystemContext _context;
        private static FeedbackDAO? instance = null;

        public FeedbackDAO()
        {
            _context = new KoiOrderingSystemContext();
        }

        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new FeedbackDAO();
                }
                return instance;
            }
        }
    }
}
