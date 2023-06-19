using API.Improvements.Application.Authentication.Commands.Register;
using API.Improvements.Contracts.Results;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace API.Improvements.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.ConvertAll(error =>
                Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return (dynamic)errors;
        }
    }
}
