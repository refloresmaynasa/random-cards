using Application.DTOs.Users;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Accounts.Commands.AuthenticateCommand
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticationResponse>>
    {
        private readonly IIdentityService _identityService;
        public AuthenticateCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Response<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.AuthenticateAsync(new AuthenticationRequest
            {
                Email = request.Email,
                Password = request.Password
            }, request.IpAddress);
        }
    }
}
