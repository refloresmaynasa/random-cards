using Application.DTOs.Users;
using Application.Wrappers;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
    }
}
