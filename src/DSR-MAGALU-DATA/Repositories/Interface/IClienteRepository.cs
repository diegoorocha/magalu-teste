using DSR_MAGALU_DATA.Entities;

namespace DSR_MAGALU_DATA.Repositories.Interface
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterTodosPaginado(Cliente cliente);
    }
}
