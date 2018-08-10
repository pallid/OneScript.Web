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
        private readonly string _lastErrorMessage;

        public InfobaseManagerContext(IServiceProvider services)
        {
            _services = services;

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            _connection = new SqliteConnection(connectionStringBuilder.ToString());

            _connection.Open();

            _lastErrorMessage = "";
        }

        /// <summary>
        /// Текст последней ошибки
        /// </summary>
        /// <value>Строка</value>
        [ContextProperty("ПоследнееСообщениеОбОшибке", "LastErrorMessage")]
        public string LastErrorMessage
        {
            get
            {
                return _lastErrorMessage;
            }
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

        public SqliteConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        /// <summary>
        /// Создать запрос с установленным соединением
        /// </summary>
        /// <returns>Запрос - Запрос с установленным соединением</returns>
        [ContextMethod("СоздатьЗапрос", "CreateQuery")]
        public Query CreateQuery()
        {
            var query = new Query();
            query.SetConnection(_connection);
            return query;
        }
    }
}