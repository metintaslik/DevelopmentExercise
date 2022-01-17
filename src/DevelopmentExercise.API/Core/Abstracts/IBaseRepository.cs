using System.Linq.Expressions;

namespace DevelopmentExercise.API.Core.Abstracts
{
    public interface IBaseRepository<T> : IAsyncDisposable where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
    }
}