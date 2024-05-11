using System.Linq.Expressions;

namespace App.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Func<T, bool> expression, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetAsync(Func<T, bool> expression);

        Task<T> GetAsync(Func<T, bool> expression, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}