namespace DevelopmentExercise.API.Core.Abstracts
{
    public interface IUnitOfWorkRepository : IAsyncDisposable
    {
        Task TransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}