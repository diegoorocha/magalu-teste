using DSR_MAGALU_BUSINESS.Resources;
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace DSR_MAGALU_BUSINESS.Exceptions
{
    [Serializable]
    public sealed class ModelInvalidoException : ArgumentException
    {
        public IEnumerable<ValidationFailure>? Errors { get; }
        public string StringKey { get; } = string.Empty;
        public string StringErro { get; } = string.Empty;

        public ModelInvalidoException(IEnumerable<ValidationFailure> errors) : base(Mensagens.ModelStateInvalido)
        {
            Errors = errors;
        }

        public ModelInvalidoException(string erro) : base(Mensagens.ModelStateInvalido)
        {
            StringErro = erro;
        }

        public ModelInvalidoException(string key, string erro) : base(Mensagens.ModelStateInvalido)
        {
            StringKey = key;
            StringErro = erro;
        }

        private ModelInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
