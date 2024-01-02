using System.Linq.Expressions;
using WebApiDemo.Entitiess.Base;

namespace WebApiDemo.Repositories.Base
{

    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByCondition(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        bool SaveChanges();
        T GetByCondition(Expression<Func<T, bool>> predicate);
    }
}
