using Configuration.Interfaces;
using Configuration.Output;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Possible.Configuration.One;
using Possible.Configuration.Two;
using Processors;
using System;

namespace Configurable.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IStandardOutput, ConsoleOutput>()
                //.AddSingleton<ITextSplitter, SimpleTextProcessor>()
                .AddSingleton<ITextSplitter, OnlyVogalsProcessor>()
                //.AddSingleton<IStarter, OneStarter>()
                .AddSingleton<IStarter, StarterTwo>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Starting application");

            try
            {
                var stdOut = serviceProvider.GetService<IStandardOutput>();

                stdOut.Write("Hello World!");

                var starter = serviceProvider.GetService<IStarter>();

                starter.Start("split me");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            logger.LogDebug("All done!");

            System.Console.ReadLine();
        }
    }
}
