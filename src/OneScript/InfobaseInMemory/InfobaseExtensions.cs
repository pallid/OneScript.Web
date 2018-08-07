using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ScriptEngine;

namespace OneScript.WebHost.Infobase
{
    public static class InfobaseExtensions
    {
        public const string ConfigSectionName = "Infobase";

        public static void AddInfobaseInMemory(this IServiceCollection services, IConfiguration config)
        {

            //AddInfobaseOptions(services);

            services.AddEntityFrameworkSqlite()
                    .AddDbContext<ApplicationIbContext>(
                        options => options.UseSqlite("DataSource=:memory:"));

        }

        private static void AddInfobaseOptions(IServiceCollection services)
        {
            services.AddTransient<DbContextOptions<ApplicationIbContext>>();
        }

        private static DbContextOptions<ApplicationIbContext> ConfigureIbOptions(IServiceProvider serviceProvider)
        {
            var builder = new DbContextOptionsBuilder<ApplicationIbContext>();

            builder.UseSqlite("DataSource=:memory:");

            return builder.Options;
        }

        public static void PrepareIbEnvironment(IServiceProvider services, RuntimeEnvironment environment)
        {
            var dbctx = services.GetService<ApplicationIbContext>();

            var infobase = new InfobaseManagerContext(services);


            environment.InjectGlobalProperty(infobase, "ИнформационнаяБаза", true);
                environment.InjectGlobalProperty(infobase, "InfoBase", true);
        }
    }

}
