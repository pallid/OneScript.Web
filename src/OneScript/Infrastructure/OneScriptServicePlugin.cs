﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ScriptEngine.HostedScript;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace OneScript.WebHost.Infrastructure
{
    public static class OneScriptServicePlugin
    {
        public static void AddOneScript(this IServiceCollection services, string applicationRoot)
        {
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IApplicationModelProvider, OscriptApplicationModelProvider>());

            var factory = new OneScriptScriptFactory(applicationRoot);
            services.AddSingleton(factory);
            
        }
    }
}
