namespace DSR_MAGALU_BUSINESS.Exceptions
{
    [Serializable]
    public sealed class InputInvalidoException : ArgumentException
    {
        public string TipoToater { get; } = string.Empty;
        public string Mensagem { get; } = string.Empty;

        public InputInvalidoException(string tipoToaster, string mensagem)
        {
            Mensagem = mensagem;
            TipoToater = tipoToaster;
        }
    }
}
