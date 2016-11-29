using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace AspNet.Core.Web.App.InitialSetup
{
    internal static class SeriLogSetup
    {
        // http://blachniet.com/blog/serilog-good-habits/
        internal static void ConfigureSeriLog(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var columnOptions = new ColumnOptions
            {
                AdditionalDataColumns = new Collection<DataColumn>
                {
                    new DataColumn {DataType = typeof (string), ColumnName = "User"},
                    new DataColumn {DataType = typeof (string), ColumnName = "Other"},
                }
            };

            columnOptions.Store.Add(StandardColumn.LogEvent);

            services.AddSingleton<Serilog.ILogger>(x => new LoggerConfiguration()
                                                       .MinimumLevel.Information()
                                                       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                                                       .MinimumLevel.Override("System", LogEventLevel.Error)
                                                       .WriteTo.MSSqlServer(configuration["Serilog:ConnectionString"],
                                                                               configuration["Serilog:TableName"], LogEventLevel.Information, columnOptions: columnOptions)
                                                   .CreateLogger());
        }
    }
}
