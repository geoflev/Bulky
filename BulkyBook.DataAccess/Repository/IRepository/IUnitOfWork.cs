namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICoverTypeRepository CoverTypeRepository { get; }
        IProductRepository ProductRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrderHeaderRepository OrderHeaderRepository { get; }
        void Save();
    }
}
