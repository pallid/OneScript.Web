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
        public static void PrepareIbEnvironment(IServiceProvider services, RuntimeEnvironment environment)
        {
            var infobase = new InfobaseManagerContext(services);

            environment.InjectGlobalProperty(infobase, "ИнформационнаяБаза", true);
            environment.InjectGlobalProperty(infobase, "InfoBase", true);
        }
    }

}
