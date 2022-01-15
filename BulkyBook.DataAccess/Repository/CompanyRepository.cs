using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            var objFromDb = _db.Companies.FirstOrDefault(company => company.Id == company.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = company.Name;
                objFromDb.StreetAddress = company.StreetAddress;
                objFromDb.City = company.City;
                objFromDb.State = company.State;
                objFromDb.PostalCode = company.PostalCode;
                objFromDb.PhoneNumber = company.PhoneNumber;
            }
        }
    }
}
