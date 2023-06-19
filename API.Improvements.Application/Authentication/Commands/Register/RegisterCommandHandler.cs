using API.Improvements.Contracts.Results;
using MediatR;

namespace API.Improvements.Application.Authentication.Commands.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        public Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
