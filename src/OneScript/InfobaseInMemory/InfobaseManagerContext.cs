using System;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using Microsoft.Data.Sqlite;
using OScriptSql;

namespace OneScript.WebHost.Infobase
{
    [ContextClass("МенеджерИнформационнойБазы", "InfoBaseManager")]
    public class InfobaseManagerContext : AutoContext<InfobaseManagerContext>
    {
        private readonly IServiceProvider _services;
        private readonly SqliteConnection _connection;

        public InfobaseManagerContext(IServiceProvider services)
        {
            _services = services;

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            _connection = new SqliteConnection(connectionStringBuilder.ToString());

            _connection.Open();
        }

        [ContextMethod("ВыполнитьКоманду")]
        public int GetUsers(string srt)
        {
   
            SqliteCommand cmd = new SqliteCommand(srt, _connection);

            var res = cmd.ExecuteNonQuery();

            return res;
        
        }

        [ContextMethod("Выполнить")]
        public IValue GetUserss(string srt)
        {

            SqliteCommand cmd = new SqliteCommand(srt, _connection);
         
            var reader = cmd.ExecuteReader();

            var result = new QueryResult(reader);

            return result;


        }
    }
}