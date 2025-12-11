using Microsoft.AspNetCore.Identity;
using MuratYilmaz.Domain.Entities;

namespace MuratYilmaz.WebAPI.Middlewares
{
    public static class ExtensionsMiddleware
    {
        public static void CreateFirstUser(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!userManager.Users.Any(p => p.UserName == "admin"))
                {
                    AppUser user = new()
                    {
                        UserName = "murat",
                        Email = "murat@gmail.com",
                        FirstName = "Murat",
                        LastName = "Yılmaz",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(user, "MuratYilmaz44").Wait();
                }
            }
        }
    }
}
