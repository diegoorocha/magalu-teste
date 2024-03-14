using DSR_MAGALU_DATA.Context;
using DSR_MAGALU_DATA.Entities;
using DSR_MAGALU_DATA.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DSR_MAGALU_DATA.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly MagaluDBContext _dbContext;
        protected readonly DbSet<TEntity> _DbSet;

        public BaseRepository(MagaluDBContext dbContext)
        {
            _dbContext = dbContext;
            _DbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> AdicionarAsync(TEntity entidade)
        {
            try
            {
                _DbSet.Add(entidade);

                await Salvar();

                return entidade;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> Atualizar(TEntity entidade)
        {
            try
            {
                _dbContext.Update(entidade);

                await Salvar();

                return entidade;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            try
            {
                return await _DbSet.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _DbSet.Where(predicate).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity?> ObterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _DbSet.Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosPaginadoAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _DbSet.Where(predicate).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> Salvar()
        {
            try
            {
                return await _dbContext.SaveChangesAsync() == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }



        #region Paginação
        protected async Task<Paginacao<TEntity>> PaginarLista(IQueryable<TEntity> query, int pagina, int tamanhoPagina)
        {
            var quantidadeTotal = await _DbSet.CountAsync();

            return await PaginarLista(query, quantidadeTotal, pagina, tamanhoPagina);
        }

        protected async Task<Paginacao<TEntity>> PaginarLista(IQueryable<TEntity> query, int quantidadeTotal, int pagina, int tamanhoPagina)
        {

            var itens = await query
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            var paginacao = new Paginacao<TEntity>
            {
                Itens = itens,
                Pagina = pagina,
                QuantidadeTotalItens = quantidadeTotal,
                TamanhoPagina = tamanhoPagina
            };

            return paginacao;
        }
        #endregion Paginação
    }
}
