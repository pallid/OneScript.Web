using Microsoft.AspNetCore.Hosting;
using OneScript.WebHost.Application;
//using OneScript.WebHost.Infobase;
using ScriptEngine.Machine;

namespace OneScript.WebHost.Infrastructure
{
    public interface IApplicationFactory
    {
        ApplicationInstance CreateApp();
    }
}
