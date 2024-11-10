
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Repository.IRepo;
using KoiOrderingSystem_Service.IService;

namespace KoiOrderingSystem_Service.Service
{
    public class OrderKoiService : IOrderKoiService
    {
        private readonly IOrderKoiRepo _repo;



        // Constructor to initialize the repository
        public OrderKoiService(IOrderKoiRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Add a new OrderKoi
        public async Task<bool> AddAsync(OrderKoi add)
        {
            if (add == null)
            {
                throw new ArgumentNullException(nameof(add), "OrderKoi cannot be null.");
            }
            if (add.Price < 0)
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            return await _repo.Add(add);
        }

        // Retrieve all OrderKoi records
        public async Task<List<OrderKoi>> GetAlls()
        {
            return await _repo.GetAll();
        }

        // Retrieve a OrderKoi by ID
        public async Task<OrderKoi?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        // Update an existing OrderKoi
        public async Task<bool> UpdateAsync(OrderKoi orderKoi)
        {
            if (orderKoi == null)
            {
                throw new ArgumentNullException(nameof(orderKoi), "OrderKoi cannot be null.");
            }
            if (orderKoi.Price < 0)
            {
                throw new Exception("Price cannot be smaller than 0");
            }
            return await _repo.Update(orderKoi);
        }

        // Delete a OrderKoi
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.Remove(id);
        }

        public async Task<List<OrderKoi>> ReadAlls()
        {
            return await _repo.ReadAll();
        }

        public async Task<OrderKoi?> ReadById(int id)
        {
            return await _repo.ReadById(id);
        }
    }

}
