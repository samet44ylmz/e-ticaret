using MuratYilmaz.Application.Features.Auth.Login;
using MuratYilmaz.Domain.Entities;

namespace MuratYilmaz.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
