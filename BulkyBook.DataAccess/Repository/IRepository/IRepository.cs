using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // Generic repo for common tasks ( update isnt one of
        // them because every update may have a different implementation )

        //fe. _db.Categories.FirstOrDefault(u=>u.Name == "geo")
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities); 
    }
}
