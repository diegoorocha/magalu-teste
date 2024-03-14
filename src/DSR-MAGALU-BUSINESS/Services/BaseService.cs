using AutoMapper;
using DSR_MAGALU_BUSINESS.Exceptions;
using DSR_MAGALU_BUSINESS.Services.Interface;
using FluentValidation;
using FluentValidation.Results;

namespace DSR_MAGALU_BUSINESS.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Validação Model State com Fluent Validator

        protected static bool ModelStateValido<T>(T model, IValidator<T> validator,
                            out IEnumerable<ValidationFailure> errors, params string[] rules)
        {
            var result = validator.Validate(model, options => options.IncludeRuleSets(rules));
            errors = result.Errors;
            return result.IsValid;
        }


        #endregion Validação Model State com Fluent Validator
    }
}
