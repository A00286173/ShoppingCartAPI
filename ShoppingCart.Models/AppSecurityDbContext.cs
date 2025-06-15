using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{
    public class AppSecurityDbContext: IdentityDbContext<IdentityUser>
    {
        public AppSecurityDbContext(DbContextOptions<AppSecurityDbContext> options)
           : base(options) { }
    }
}
