using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository
{
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiDAO koiDAO;
        public void addKoi(Koi koi) => KoiDAO.Instance.Add(koi);

        public void removeKoi(Koi koiId) => KoiDAO.Instance.Remove(koiId);

        public Koi getKoiById(int koiId) => KoiDAO.Instance.GetById(koiId);
        public void updateKoi(Koi koi) => KoiDAO.Instance.Update(koi);
        public List<Koi> getall() => KoiDAO.Instance.GetAll();
        // Singleton instance of KoiDAO

    }
}
