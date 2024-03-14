using System.Linq.Expressions;

namespace DSR_MAGALU_DATA.Repositories.Interface
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AdicionarAsync(TEntity entidade);
        Task<TEntity> Atualizar(TEntity entidade);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<IEnumerable<TEntity>> ObterTodosAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> ObterTodosPaginadoAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> ObterAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
