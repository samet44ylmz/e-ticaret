using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using TS.Result;

namespace MuratYilmaz.Application.Features.Users.CreateUser;

internal sealed class CreateUserCommandHandler(
    
    ICacheService cacheService,
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool isUserNameExists = await userManager.Users.AnyAsync(p => p.UserName == request.UserName, cancellationToken);

        if (isUserNameExists)
        {
            return Result<string>.Failure("Bu kullanıcı adı daha önce kullanılmış");
        }

        bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == request.Email, cancellationToken);

        if (isEmailExists)
        {
            return Result<string>.Failure("Bu mail adresi daha önce kullanılmış");
        }

        AppUser appUser = mapper.Map<AppUser>(request);

        IdentityResult identityResult = await userManager.CreateAsync(appUser, request.Password);

        if (!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
        }

     

      
        await unitOfWork.SaveChangesAsync(cancellationToken);

        cacheService.Remove("users");

       


        return "Kullanıcı kaydı başarıyla tamamlandı";
    }
}