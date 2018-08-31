//#define TEXT_COMFIG
//#define TEXT_2
//#define TEXT_2_1
#define TYPED_CONFIG
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
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging();
            serviceCollection.AddSingleton<IStandardOutput, ConsoleOutput>();
#if TEXT_COMFIG
#if TEXT_1
            serviceCollection.AddSingleton<IStarter, OneStarter>();
#endif

#if TEXT_2
#if TEXT_2_1
            serviceCollection.AddSingleton<ITextSplitter, SimpleTextProcessor>();
#endif
#if TEXT_2_2
            serviceCollection.AddSingleton<ITextSplitter, OnlyVogalsProcessor>();
#endif
            serviceCollection.AddSingleton<IStarter, StarterTwo>();
#endif
#endif

#if TYPED_CONFIG
            serviceCollection.AddSingleton<IStarter, StrongStarterOne>();
#endif
            var serviceProvider = serviceCollection.BuildServiceProvider();

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

#if TYPED_CONFIG
                    OneIntegerThingy oneThingy = new OneIntegerThingy();

                    oneThingy.OneProperty = 1;
                    oneThingy.AnotherProperty = 2;
                    oneThingy.YetAnotherProperty = 3;

                    starter.Start(oneThingy);
#endif
#if TEXT_COMFIG
                    starter.Start("split me");
#endif
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
