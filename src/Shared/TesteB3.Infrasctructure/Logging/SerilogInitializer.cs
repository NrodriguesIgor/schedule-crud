using NpgsqlTypes;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace TesteB3.Infrasctructure.Logging
{
    public class SerilogInitializer
    {
        public SerilogInitializer()
        {
            var sqlPath = Environment.CurrentDirectory + @"/app.db";

            IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
                {
                    {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
                    {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
                    {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
                    {"raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
                    {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
                    {"properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
                    {"props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
                };

            var configuration = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                .MinimumLevel.Override("System", LogEventLevel.Verbose)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Verbose)
                .MinimumLevel.Override("Quartz", LogEventLevel.Verbose)
                .WriteTo.Async(x =>x.Console())
                .WriteTo.Async(x => x.PostgreSQL(connectionString:Environment.GetEnvironmentVariable("POSTGRES_CONNECTIONSTRING"), tableName: "logs", columnWriters, needAutoCreateTable: true));

            Log.Logger = configuration.CreateLogger();
        }
    }
}
