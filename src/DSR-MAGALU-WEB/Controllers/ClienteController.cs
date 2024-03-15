using DSR_MAGALU_BUSINESS.Exceptions;
using DSR_MAGALU_BUSINESS.Models;
using DSR_MAGALU_BUSINESS.Resources;
using DSR_MAGALU_BUSINESS.Services.Interface;
using DSR_MAGALU_WEB.NotificationToaster.Interface;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DSR_MAGALU_WEB.Controllers
{
    public class ClienteController : BaseController<ClienteController>
    {
        private readonly IClienteService _clienteService;
        private readonly IToasterService _toasterService;

        public ClienteController(IClienteService clienteService, IToasterService toasterService)
        {
            _clienteService = clienteService;
            _toasterService = toasterService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            var listaClientes = await _clienteService.BuscarPaginadoAsync(null);
            var clienteViewModel = new ClienteViewModel
            {
                Lista = listaClientes.ToPagedList(pagina, 20)
            };

            return View(clienteViewModel);
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(ClienteViewModel clienteViewModel, int pagina = 1)
        {
            var listaClientes = await _clienteService.BuscarPaginadoAsync(clienteViewModel);

            clienteViewModel.Lista = listaClientes.ToPagedList(pagina, 20);

            return View(clienteViewModel);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var model = new ClienteViewModel() { DataCadastro = DateTime.UtcNow };
            return View(model);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(ClienteViewModel clienteViewModel)
        {
            try
            {
                LimparErrosModelStateInvalido("Lista");

                if (ModelState.IsValid)
                {
                    await _clienteService.CadastrarAsync(clienteViewModel);

                    _toasterService.AdicionarToaster("sucesso", string.Format(Mensagens.ClienteCadastradoSucesso, clienteViewModel.NomeClienteRazaoSocial));

                    return RedirectToAction("Index");
                }
                _toasterService.AdicionarToaster();
            }
            catch (ModelInvalidoException ex)
            {
                _toasterService.AdicionarToaster(ex!.Errors!);
            }
            catch (InputInvalidoException ex)
            {
                _toasterService.AdicionarToaster(ex.TipoToater, ex.Mensagem);
            }
            catch (Exception)
            {
                _toasterService.AdicionarToaster();
            }

            return View(clienteViewModel);
        }

        [HttpGet]
        [Route("detalhes/{id:guid}")]
        public async Task<IActionResult> Detalhes(Guid id, int pagina = 1, int tamanhoPagina = 20)
        {
            var model = await _clienteService.ObterClientePorIdAsync(id, pagina, tamanhoPagina);
            return View(model);
        }

        [HttpGet("editar/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id, int pagina = 1, int tamanhoPagina = 20)
        {
            var model = await _clienteService.ObterClientePorIdAsync(id, pagina, tamanhoPagina);
            return View(model);
        }

        [HttpPost("editar/{id:guid}")]
        public async Task<IActionResult> Editar(ClienteViewModel clienteViewModel)
        {
            try
            {
                LimparErrosModelStateInvalido("Lista", "ConfirmaSenha");

                if (ModelState.IsValid)
                {
                    await _clienteService.EditarAsync(clienteViewModel);

                    _toasterService.AdicionarToaster("sucesso", string.Format(Mensagens.ClienteEditadoSucesso, clienteViewModel.NomeClienteRazaoSocial));

                    return RedirectToAction("Index");
                }
                _toasterService.AdicionarToaster();
            }
            catch (ModelInvalidoException ex)
            {
                _toasterService.AdicionarToaster(ex!.Errors!);
            }
            catch (InputInvalidoException ex)
            {
                _toasterService.AdicionarToaster(ex.TipoToater, ex.Mensagem);
            }
            catch (Exception)
            {
                _toasterService.AdicionarToaster();
            }

            return View(clienteViewModel);
        }
        #region CHAMADAS POR AJAX

        [HttpPost]
        public async Task<JsonResult> ValidarEmail(string email)
        {
            var (tipoToaster, mensagemToaster, validado) = await _clienteService.ValidarEmail(email, true);

            _toasterService.AdicionarToaster(tipoToaster, mensagemToaster);
            return Json(validado);
        }

        [HttpPost]
        public async Task<JsonResult> ValidarDocumentoCpfCnpj(string documento)
        {
            var (tipoToaster, mensagemToaster, validado) = await _clienteService.ValidarDocumentoCpfCnpj(documento, true);

            _toasterService.AdicionarToaster(tipoToaster, mensagemToaster);
            return Json(validado);
        }

        [HttpPost]
        public async Task<JsonResult> ValidarInscricaoEstadual(string inscricaoEstadual)
        {
            var (tipoToaster, mensagemToaster, validado) = await _clienteService.ValidarInscricaoEstadual(inscricaoEstadual, true);

            _toasterService.AdicionarToaster(tipoToaster, mensagemToaster);
            return Json(validado);
        }

        #endregion CHAMADAS POR AJAX
    }
}