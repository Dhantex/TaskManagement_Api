using TaskManagement.Application.Models.Identity;

namespace TaskManagement.Application.Contracts.Infrastructure
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
