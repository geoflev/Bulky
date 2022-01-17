using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.Update(orderHeader);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var objFromDb = _db.OrderHeaders.FirstOrDefault(header => header.Id == id);
            if (objFromDb != null)
            {
                objFromDb.OrderStatus = orderStatus;
                if(paymentStatus != null)
                {
                    objFromDb.PaymentStatus = paymentStatus;
                }
            }
        }
    }
}
