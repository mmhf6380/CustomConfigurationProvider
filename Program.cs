using CustomConfigurationProvider.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CustomConfigurationProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    var config = configuration.Build();
                    var configSource = new DBConfigurationSource(opts =>
                        opts.UseSqlServer(config.GetConnectionString("sqlConnection")));
                    configuration.Add(configSource);
                });
    }
}
