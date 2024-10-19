using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository
{
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiDAO koiDAO;
        public void addKoi(Koi koi)=>KoiDAO.Instance.AddKoi(koi);

        public void removeKoi(Koi koiId) => KoiDAO.Instance.RemoveKoi(koiId);

        public Koi getKoiById(int koiId)=>KoiDAO.Instance.GetKoiById(koiId);
        public void updateKoi(Koi koi)=>KoiDAO.Instance.UpdateKoi(koi);
        public List<Koi> getall()=> KoiDAO.Instance.GetAllKoi();
        // Singleton instance of KoiDAO
        
    }
}
