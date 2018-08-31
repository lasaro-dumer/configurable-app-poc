using Configuration.Interfaces;
using Configuration.Output;
using Domain.Types.One;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Possible.Configuration.One;
using Possible.Configuration.Two;
using Processors;
using StronglyTyped.Starters;
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
                //.AddSingleton<IStarter, StarterTwo>()
                .AddSingleton<IStarter, StrongStarterOne>()
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

                if (starter is StrongStarterOne)
                {
                    OneIntegerThingy oneThingy = new OneIntegerThingy();

                    oneThingy.OneProperty = 1;
                    oneThingy.AnotherProperty = 2;
                    oneThingy.YetAnotherProperty = 3;

                    starter.Start(oneThingy);
                }
                else
                {
                    starter.Start("split me");
                }
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
