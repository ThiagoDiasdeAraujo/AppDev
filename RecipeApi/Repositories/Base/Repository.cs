using System.Linq.Expressions;
using RecipeApi.Data;
using RecipeApi.Entities.Base;

namespace RecipeApi.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T GetByCondition(Expression<Func<T, bool>> predicate)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Set<T>().Where(predicate).SingleOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllByCondition(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
