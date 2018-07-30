using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneScript.WebHost.Infobase;
using OneScript.WebHost.Infrastructure;
using OneScript.WebHost.Identity;

namespace OneScript.WebHost.Infobase
{
    public class ApplicationIbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationIbContext(DbContextOptions<ApplicationIbContext> options):base(options)
        {
        }

        public IApplicationRuntime RuntimeFacility { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
        //    base.OnModelCreating(modelBuilder);
       // }
    }
}
