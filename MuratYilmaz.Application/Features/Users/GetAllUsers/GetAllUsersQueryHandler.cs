using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using TS.Result;

namespace MuratYilmaz.Application.Features.Users.GetAllUsersQuery;

internal sealed class GetAllUsersQueryHandler(
    ICacheService cacheService,
    UserManager<AppUser> userManager) : IRequestHandler<GetAllUsersQuery, Result<List<AppUser>>>
{
    public async Task<Result<List<AppUser>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<AppUser>? users;

        users = cacheService.Get<List<AppUser>>("users");

        if (users is null)
        {
            users = await userManager.Users
                 
                   .OrderBy(p => p.FirstName)
                   .ToListAsync(cancellationToken);

            cacheService.Set<List<AppUser>>("users", users);
        }

        return users;
    }
}