using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;


namespace SixPivotApp.Common
{
    public static class LoggerConfig
    {
        public static void RegisterLogger()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            string appSettingsEnvFile = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";

            if (File.Exists(appSettingsEnvFile))
                configurationBuilder = configurationBuilder.AddJsonFile(appSettingsEnvFile);

            IConfigurationRoot configuration = configurationBuilder.Build();

            LoggerConfiguration logConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configuration);

            Log.Logger = logConfig.CreateLogger();
        }

    }
}
