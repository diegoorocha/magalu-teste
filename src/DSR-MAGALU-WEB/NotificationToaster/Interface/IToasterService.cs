using FluentValidation.Results;

namespace DSR_MAGALU_WEB.NotificationToaster.Interface
{
    public interface IToasterService
    {
        void AdicionarToaster(string tipoToaster, string mensagem);
        void AdicionarToaster(IEnumerable<ValidationFailure> errors);
        void AdicionarToaster();
    }
}
