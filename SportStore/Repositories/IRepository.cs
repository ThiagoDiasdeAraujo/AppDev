using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.Entities;
using System.Linq.Expressions;

namespace SportStore.Repositories
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
