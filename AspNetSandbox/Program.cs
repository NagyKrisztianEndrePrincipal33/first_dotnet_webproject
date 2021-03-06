using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox
{
    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option('c', "connectionString", Required = false, HelpText = "Set the connection string.")]
            public string ConnectionString { get; set; }
        }

        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
                  {
                      if (o.Verbose)
                      {
                          Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                          Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                      }
                      else
                      {
                          Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                          Console.WriteLine("Quick Start Example!");
                      }

                      if (o.ConnectionString != null)
                      {
                          Console.WriteLine($"Connection string is: {o.ConnectionString}");
                      }
                  });
            if (args.Length > 0)
            {
                Console.WriteLine($"There are : {args.Length} arguments.");
            }
            else
            {
                Console.WriteLine("No Arguments!");
            }

            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
