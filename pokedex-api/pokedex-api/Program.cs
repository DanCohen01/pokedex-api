using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pokedex.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
           //.MinimumLevel.Information
           .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
           .Enrich.FromLogContext()
           .Enrich.WithExceptionDetails()
           .Enrich.WithDemystifiedStackTraces()
           .WriteTo.File(
               new JsonFormatter(renderMessage: true),
               Path.Combine(AppContext.BaseDirectory, "logs//pokedex-logs.json"),
               shared: true,
               fileSizeLimitBytes: 20_971_520,
               rollOnFileSizeLimit: true,
               retainedFileCountLimit: 10)
           .CreateLogger();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
