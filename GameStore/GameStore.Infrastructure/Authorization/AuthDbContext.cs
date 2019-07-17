using GameStore.Infrastructure.Authorization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Authorization
{
    public class AuthDbContext : IdentityDbContext<AuthUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) 
            : base(options)
        {
        }

        public DbSet<AuthUser> AuthUser { get; set; }        
    }
}
