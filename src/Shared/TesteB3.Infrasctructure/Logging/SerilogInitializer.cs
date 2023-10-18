using Serilog;
using Serilog.Events;

namespace TesteB3.Infrasctructure.Logging
{
    public class SerilogInitializer
    {
        public SerilogInitializer()
        {
            var sqlPath = Environment.CurrentDirectory + @"/app.db";

            var configuration = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                .MinimumLevel.Override("System", LogEventLevel.Verbose)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Verbose)
                .MinimumLevel.Override("Quartz", LogEventLevel.Verbose)
                .WriteTo.Async(x =>x.Console())
                .WriteTo.Async(x => x.SQLite(sqliteDbPath: sqlPath, tableName: "Log", batchSize: 1));

            Log.Logger = configuration.CreateLogger();
        }
    }
}
