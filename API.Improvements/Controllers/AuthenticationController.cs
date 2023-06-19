using API.Improvements.Application.Authentication.Commands.Register;
using API.Improvements.Contracts.Results;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Improvements.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand request)
        {
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(request);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));

        }
    }
}
