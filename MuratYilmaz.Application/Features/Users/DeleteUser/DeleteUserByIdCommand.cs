using MediatR;
using Microsoft.AspNetCore.Identity;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Users.DeleteUser;

public sealed record DeleteUserByIdCommand(
    Guid Id) : IRequest<Result<string>>;



internal sealed class DeleteUserByIdCommandHandler(
    ICacheService cacheService,
    UserManager<AppUser> userManager) : IRequestHandler<DeleteUserByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByIdAsync(request.Id.ToString());

        if (appUser is null)
        {
            return Result<string>.Failure("Kullanıcı bulunamadı");
        }


        IdentityResult identityResult = await userManager.UpdateAsync(appUser);


        if (!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
        }

        cacheService.Remove("users");

        return "Kullanıcı başarıyla silindi";
    }
}