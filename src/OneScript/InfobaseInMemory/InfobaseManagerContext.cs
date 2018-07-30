using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OneScript.WebHost.Infobase;
using OneScript.WebHost.Identity;
using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;


namespace OneScript.WebHost.Infobase
{
    [ContextClass("МенеджерИнформационнойБазы", "InfoBaseManager")]
    public class InfobaseManagerContext : AutoContext<InfobaseManagerContext>
    {
        private readonly IServiceProvider _services;

        public InfobaseManagerContext(IServiceProvider services)
        {
            _services = services;
        }

        [ContextMethod("ПолучитьПользователей")]
        public int GetUsers(string srt)
        {
            var dbctx = _services.GetService<ApplicationIbContext>();
            var res = dbctx.Database.ExecuteSqlCommand(srt);

            return res;
        }
    }
}