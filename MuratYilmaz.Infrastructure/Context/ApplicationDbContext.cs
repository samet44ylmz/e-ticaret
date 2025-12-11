using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuratYilmaz.Domain.Entities;
using System.Reflection.Emit;

namespace MuratYilmaz.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);

            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();

            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}