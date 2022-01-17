using DevelopmentExercise.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevelopmentExercise.API.Core.Abstracts
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            NullCheck(entity);

            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync() => await _dbSet.ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) =>
            predicate == null ? throw new ArgumentNullException(nameof(predicate)) : await _dbSet.Where(predicate).ToListAsync().ConfigureAwait(false);

        public async Task UpdateAsync(T entity)
        {
            NullCheck(entity);

            _context.Entry(entity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            await _context.Entry(entity).ReloadAsync().ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync().ConfigureAwait(false);

            GC.SuppressFinalize(this);
        }

        private static void NullCheck(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
        }
    }
}