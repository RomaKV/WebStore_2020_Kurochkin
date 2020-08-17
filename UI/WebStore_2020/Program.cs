using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.WebStore.DAL;

namespace WebStore
{
    public class Program
    {

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(typeof(Program));
        
        public static void Main(string[] args)
        {
            //var log4NetConfig = new XmlDocument();

            //log4NetConfig.Load(File.OpenRead("log4net.config"));

            //var repo = log4net.LogManager.CreateRepository(
            //    Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            //log4net.Config.XmlConfigurator.Configure(repo, log4NetConfig["log4net"]);

            //Log.Info("Application - Main is invoked");
            
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope()) // нужно для получения DbContext
            {
                var services = scope.ServiceProvider;
                try
                {
                    WebStoreContext context = services.GetRequiredService<WebStoreContext>();
                    DbInitializer.Initialize(context);
                    DbInitializer.InitializeUsers(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Oops. Something went wrong at DB initializing...");
                }
            }

            host.Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

    }
}
