using System.Collections.ObjectModel;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace CustomLogger
{
    public static class SeriLogSetup
    {
        // http://blachniet.com/blog/serilog-good-habits/
        public static void ConfigureSeriLog(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var columnOptions = new ColumnOptions
            {
                AdditionalDataColumns = new Collection<DataColumn>
                {
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.User.ToString()},
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.Host.ToString()},
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.Enviornment.ToString()},
                    new DataColumn {DataType = typeof (string), ColumnName = CustomColumn.Other.ToString()},
                }
            };

            columnOptions.Store.Add(StandardColumn.LogEvent);

            services.AddSingleton<ILogger>(x => new LoggerConfiguration()
                                                       .MinimumLevel.Information()
                                                       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                                                       .MinimumLevel.Override("System", LogEventLevel.Error)
                                                       .WriteTo.MSSqlServer(configuration["Serilog:ConnectionString"],
                                                                               configuration["Serilog:TableName"], 
                                                                               LogEventLevel.Information, 
                                                                               columnOptions: columnOptions)
                                                   .CreateLogger());
        }
    }
}
