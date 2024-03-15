using AutoMapper;
using DSR_MAGALU_BUSINESS.Exceptions;
using DSR_MAGALU_BUSINESS.FluentValidator;
using DSR_MAGALU_BUSINESS.Helpers;
using DSR_MAGALU_BUSINESS.Models;
using DSR_MAGALU_BUSINESS.Resources;
using DSR_MAGALU_BUSINESS.Services.Interface;
using DSR_MAGALU_DATA.Entities;
using DSR_MAGALU_DATA.Repositories.Interface;
using FluentValidation.Validators;
using MySqlX.XDevAPI;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DSR_MAGALU_BUSINESS.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        const string regraCriacao = "AdicionarCliente";
        const string regraEdicao = "EditarCliente";
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository) : base(mapper)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteViewModel>> BuscarPaginadoAsync(ClienteViewModel clienteViewModel)
        {
            var parse = ParseDeClienteViewModelParaCliente(clienteViewModel);

            var clientesPaginados = await _clienteRepository.ObterTodosPaginado(parse);

            return _mapper.Map<List<ClienteViewModel>>(clientesPaginados);
        }

        public async Task CadastrarAsync(ClienteViewModel clienteViewModel)
        {
            if (ModelStateValido(clienteViewModel, new ClienteValidator(), out var validationFailures, regraCriacao))
            {
                throw new ModelInvalidoException(validationFailures);
            }

            var executarValidacao = await ExecutarValidacaoAsync(clienteViewModel);

            if (!executarValidacao.Item3)
                throw new InputInvalidoException(executarValidacao.Item1, executarValidacao.Item2);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteRepository.AdicionarAsync(cliente);
        }

        public async Task EditarAsync(ClienteViewModel clienteViewModel)
        {
            if (ModelStateValido(clienteViewModel, new ClienteValidator(), out var validationFailures, regraEdicao))
            {
                throw new ModelInvalidoException(validationFailures);
            }

            var executarValidacao = await ExecutarValidacaoAsync(clienteViewModel);

            if (!executarValidacao.Item3)
                throw new InputInvalidoException(executarValidacao.Item1, executarValidacao.Item2);

            var cliente = executarValidacao.Item4;

            await _clienteRepository.Atualizar(cliente);
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterTodosAsync()
        {
            var clientes = await _clienteRepository.ObterTodosAsync();

            return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        }

        public async Task<ClienteViewModel> ObterClientePorIdAsync(Guid clienteId, int pagina, int tamanhoPagina)
        {
            var cliente = await _clienteRepository.ObterAsync(x => x.Id == clienteId);

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        public async Task<Tuple<string, string, bool>> ValidarEmail(string email, bool validarEmail = false)
        {
            if (string.IsNullOrEmpty(email.Trim()))
                return new Tuple<string, string, bool>("info", Mensagens.EmailNaoInformado, false);

            if (!EmailHelpers.ValidarEmail(email.Trim()))
                return new Tuple<string, string, bool>("alerta", string.Format(Mensagens.EmailNaoValido, email.Trim()), false);

            if (validarEmail && await ValidarEmailJaCadastrado(email.Trim()))
            {
                return new Tuple<string, string, bool>("alerta", Mensagens.EmailJaUtilizado, false);
            }

            return new Tuple<string, string, bool>("info", string.Format(Mensagens.EmailNaoCadastrado, email.Trim()), true);
        }

        public async Task<Tuple<string, string, bool>> ValidarDocumentoCpfCnpj(string cpfCnpj, bool validarDocumento = false)
        {
            cpfCnpj = Regex.Replace(cpfCnpj, "[^0-9]", "");

            if (string.IsNullOrEmpty(cpfCnpj.Trim()))
                return new Tuple<string, string, bool>("info", Mensagens.DocumentoNaoInformado, false);

            if (!DocumentoHelpers.ValidarDocumentoCpfCnpj(cpfCnpj.Trim()))
                return new Tuple<string, string, bool>("alerta", string.Format(Mensagens.DocumentoNaoValido, cpfCnpj.Trim()), false);

            if (validarDocumento && await ValidarDocumentoCpfCnpjJaCadastrado(cpfCnpj.Trim()))
            {
                return new Tuple<string, string, bool>("alerta", Mensagens.DocumentoJaUtilizado, false);
            }

            return new Tuple<string, string, bool>("info", string.Format(Mensagens.DocumentoNaoCadastrado, cpfCnpj.Trim()), true);
        }

        public async Task<Tuple<string, string, bool>> ValidarInscricaoEstadual(string inscricaoEstadual, bool validarInscricaoEstadual = false)
        {
            inscricaoEstadual = Regex.Replace(inscricaoEstadual, "[^0-9]", "");

            if (string.IsNullOrEmpty(inscricaoEstadual.Trim()))
                return new Tuple<string, string, bool>("info", Mensagens.InscricaoEstadualNaoInformada, false);

            if (validarInscricaoEstadual && await ValidarInscricaoEstadualJaCadastrado(inscricaoEstadual.Trim()))
            {
                return new Tuple<string, string, bool>("alerta", Mensagens.InscricaoEstadualJaUtilizada, false);
            }

            return new Tuple<string, string, bool>("info", string.Format(Mensagens.InscricaoNaoCadastrada, inscricaoEstadual.Trim()), true);
        }

        #region Metodos auxiliares

        private async Task<Tuple<bool, bool, bool, Cliente>> ValidarDadosInputsEdicao(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel.Id == Guid.Empty)
                return new Tuple<bool, bool, bool, Cliente>(false, false, false, new Cliente());

            var cliente = await ObterClientePorId(clienteViewModel.Id);
            if (cliente is null)
                return new Tuple<bool, bool, bool, Cliente>(false, false, false, new Cliente());

            var emailValidar = !clienteViewModel.Email.Equals(cliente.Email);
            var documentoValidador = !clienteViewModel.Documento.Equals(cliente.Documento);
            var inscricaoEstadualValidar = !clienteViewModel.InscricaoEstadual!.Equals(cliente.InscricaoEstadual);

            return new Tuple<bool, bool, bool, Cliente>(emailValidar, inscricaoEstadualValidar, documentoValidador, cliente);
        }

        private async Task<Tuple<string, string, bool, Cliente>> ExecutarValidacaoAsync(ClienteViewModel clienteViewModel)
        {
            clienteViewModel = TratarInputsParaValidacao(clienteViewModel);

            var (validarEmail, validarInscricaoEstadual, validarDocumento, cliente) = await ValidarDadosInputsEdicao(clienteViewModel);

            #region Email

            var emailValido = await ValidarEmail(clienteViewModel.Email, validarEmail);

            if (!emailValido.Item3)
                return new Tuple<string, string, bool, Cliente>(emailValido.Item1, emailValido.Item2, emailValido.Item3, cliente);

            #endregion Email

            #region Cpf Cnpj

            var documentoValido = await ValidarDocumentoCpfCnpj(clienteViewModel.Documento, validarDocumento);

            if (!documentoValido.Item3)
                return new Tuple<string, string, bool, Cliente>(documentoValido.Item1, documentoValido.Item2, documentoValido.Item3, cliente);

            #endregion Cpf Cnpj

            #region Inscricao Estadual

            var InscricaoEstadualValida = await ValidarInscricaoEstadual(clienteViewModel.InscricaoEstadual, validarInscricaoEstadual);

            if (!InscricaoEstadualValida.Item3)
                return new Tuple<string, string, bool, Cliente>(InscricaoEstadualValida.Item1, InscricaoEstadualValida.Item2, InscricaoEstadualValida.Item3, cliente);

            #endregion Inscricao Estadual

            cliente = ParseDeClienteViewModelParaCliente(clienteViewModel);

            return new Tuple<string, string, bool, Cliente>(string.Empty, string.Empty, true, cliente);
        }

        private async Task<Cliente?> ObterClientePorId(Guid clienteId)
        {
            return await _clienteRepository.ObterAsync(s => s.Id == clienteId);
        }

        private async Task<bool> ValidarEmailJaCadastrado(string email)
        {
            var emailCadastrado = await _clienteRepository.ObterAsync(x => x.Email == email);
            return emailCadastrado != null;
        }

        private async Task<bool> ValidarDocumentoCpfCnpjJaCadastrado(string cpfCnpj)
        {
            var cpfCnpjCadastrado = await _clienteRepository.ObterAsync(x => x.Documento == cpfCnpj);

            return cpfCnpjCadastrado != null;
        }

        private async Task<bool> ValidarInscricaoEstadualJaCadastrado(string inscricaoEstadual)
        {
            var inscricaoEstadualCadastrada = await _clienteRepository.ObterAsync(x => x.InscricaoEstadual == inscricaoEstadual);

            return inscricaoEstadualCadastrada != null;
        }

        private static Cliente ParseDeClienteViewModelParaCliente(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel is not null)
            {
                return new Cliente()
                {
                    NomeClienteRazaoSocial = clienteViewModel.NomeClienteRazaoSocial,
                    Email = clienteViewModel.Email,
                    Telefone = clienteViewModel.Telefone,
                    DataCadastro = clienteViewModel.DataCadastro,
                    Documento = clienteViewModel.Documento,
                    Bloqueado = clienteViewModel.Bloqueado,
                    DataNascimento = clienteViewModel.DataNascimento,
                    Genero = (int)clienteViewModel.Genero,
                    Id = clienteViewModel.Id,
                    InscricaoEstadual = clienteViewModel.InscricaoEstadual,
                    Isento = clienteViewModel.Isento,
                    Senha = clienteViewModel.Senha,
                    TipoPessoa = (int)clienteViewModel.TipoPessoa
                };
            }
            return new Cliente();
        }

        private static ClienteViewModel TratarInputsParaValidacao(ClienteViewModel clienteViewModel)
        {
            clienteViewModel.InscricaoEstadual = Regex.Replace(clienteViewModel.InscricaoEstadual, "[^0-9]", "");
            clienteViewModel.Documento = Regex.Replace(clienteViewModel.Documento, "[^0-9]", "");

            return clienteViewModel;
        }

        #endregion Metodos auxiliares
    }
}