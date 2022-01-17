using DevelopmentExercise.API.Core.Abstracts;
using DevelopmentExercise.API.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace DevelopmentExercise.API.Core.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationContext _context;
        private IDbContextTransaction _transaction = null!;

        public UnitOfWorkRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync().ConfigureAwait(false);
            await DisposeAsync().ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
                await _transaction.DisposeAsync().ConfigureAwait(false);
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync().ConfigureAwait(false);
            await DisposeAsync().ConfigureAwait(false);
        }

        public async Task TransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }
    }
}