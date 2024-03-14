using DSR_MAGALU_BUSINESS.Resources;
using DSR_MAGALU_WEB.NotificationToaster.Interface;
using FluentValidation.Results;
using NToastNotify;

namespace DSR_MAGALU_WEB.NotificationToaster
{
    public class ToasterService : IToasterService
    {
        private readonly IToastNotification _notyfService;
        public ToasterService(IToastNotification notyfService)
        {
            _notyfService = notyfService;
        }

        public void AdicionarToaster(string tipoToaster, string mensagem)
        {
            switch (tipoToaster)
            {
                case "info":
                    AdicionarInformacaoToaster(mensagem);
                    break;

                case "alerta":
                    AdicionarAlertaToaster(mensagem);
                    break;

                case "error":
                    AdicionarErrorToaster(mensagem);
                    break;

                default:
                    AdicionarSucessoToaster(mensagem);
                    break;
            }
        }

        public void AdicionarToaster(IEnumerable<ValidationFailure> errors)
        {
            AdicionarErrorToaster(errors);
        }

        public void AdicionarToaster()
        {
            AdicionarErrorToaster();
        }

        #region Notificações Error

        private void AdicionarErrorToaster(IEnumerable<ValidationFailure> errors)
        {
            foreach (var error in errors.ToList())
                _notyfService.AddErrorToastMessage(error.ErrorMessage);
        }
        private void AdicionarErrorToaster()
        {
            _notyfService.AddErrorToastMessage(Mensagens.ErroInesperado);
        }
        private void AdicionarErrorToaster(string mensagem)
        {
            _notyfService.AddErrorToastMessage(mensagem);
        }

        #endregion Notificações Error

        #region Notificações Warning

        private void AdicionarAlertaToaster(string mensagem)
        {
            _notyfService.AddWarningToastMessage(mensagem);
        }

        #endregion Notificações Warning

        #region Notificações Sucesso

        private void AdicionarSucessoToaster(string mensagem)
        {
            _notyfService.AddSuccessToastMessage(mensagem);
        }

        #endregion Notificações Sucesso

        #region Notificações Informação

        private void AdicionarInformacaoToaster(string mensagem)
        {
            _notyfService.AddInfoToastMessage(mensagem);
        }

        #endregion Notificações Informação
    }
}
