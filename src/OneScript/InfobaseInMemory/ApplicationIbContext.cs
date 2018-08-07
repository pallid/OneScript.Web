using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneScript.WebHost.Infobase;
using OneScript.WebHost.Infrastructure;
using OneScript.WebHost.Identity;

namespace OneScript.WebHost.Infobase
{
    public class ApplicationIbContext : DbContext
    {
        public ApplicationIbContext(DbContextOptions<ApplicationIbContext> options):base(options)
        {
        }
    }
}
