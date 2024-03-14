using DSR_MAGALU_DATA.Context;
using DSR_MAGALU_DATA.Entities;
using DSR_MAGALU_DATA.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace DSR_MAGALU_DATA.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly MagaluDBContext _context;

        public ClienteRepository(MagaluDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObterTodosPaginado(Cliente cliente)
        {
            IQueryable<Cliente> query = _context.Cliente
                .AsNoTracking()
                .IgnoreQueryFilters();

            if (!string.IsNullOrEmpty(cliente.NomeClienteRazaoSocial))
                query = query.Where(t => EF.Functions.Like(t.NomeClienteRazaoSocial, $"%{cliente.NomeClienteRazaoSocial}%"));

            if (!string.IsNullOrEmpty(cliente.Email))
                query = query.Where(t => EF.Functions.Like(t.Email, $"%{cliente.Email}%"));

            if (!string.IsNullOrEmpty(cliente.Telefone))
                query = query.Where(t => EF.Functions.Like(t.Telefone, $"%{cliente.Telefone}%"));

            if (cliente.DataCadastro.HasValue && cliente.DataCadastro != new DateTime(1, 1, 1))
                query = query.Where(t => t.DataCadastro == cliente.DataCadastro);

            query = query.Where(t => t.Bloqueado == cliente.Bloqueado);

            return await Task.FromResult(query.OrderBy(x => x.DataCadastro).ToList());
        }
    }
}