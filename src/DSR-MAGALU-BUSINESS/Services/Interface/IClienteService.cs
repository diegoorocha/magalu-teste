using DSR_MAGALU_BUSINESS.Models;

namespace DSR_MAGALU_BUSINESS.Services.Interface
{
    public interface IClienteService
    {
        Task CadastrarAsync(ClienteViewModel clienteViewModel);
        Task EditarAsync(ClienteViewModel clienteViewModel);
        Task<ClienteViewModel> ObterClientePorIdAsync(Guid clienteId, int pagina, int tamanhoPagina);
        Task<IEnumerable<ClienteViewModel>> ObterTodosAsync();
        Task<Tuple<string, string, bool>> ValidarEmail(string email, bool validar = false);
        Task<Tuple<string, string, bool>> ValidarDocumentoCpfCnpj(string cpfCnpj, bool validar = false);
        Task<Tuple<string, string, bool>> ValidarInscricaoEstadual(string inscricaoEstadual, bool validar = false);
        Task<List<ClienteViewModel>> BuscarPaginadoAsync(ClienteViewModel clienteViewModel);
    }
}
