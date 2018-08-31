using Configuration.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Possible.Configuration.Two
{
    public class StarterTwo : IStarter
    {
        private IStandardOutput Output { get; set; }
        private ITextSplitter Splitter { get; set; }
        private ILogger<StarterTwo> Logger { get; }

        public StarterTwo(IStandardOutput output, ITextSplitter splitter, ILogger<StarterTwo> logger)
        {
            Output = output;
            Splitter = splitter;
            Logger = logger;
        }

        public void Start(params object[] startParams)
        {
            try
            {
                Logger.LogInformation($"Starting processing...");
                if (startParams.Length < 1)
                {
                    throw new ArgumentException("The starter need at least one argument");
                }
                else
                {
                    Output.Write("Starter starting....");

                    var text = startParams[0].ToString();

                    var splitted = Splitter.SplitText(text);

                    Output.Write($"Split result:");

                    foreach (var t in splitted)
                        Output.Write(t);
                }
                Logger.LogInformation($"Processing done...");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                Logger.LogDebug(ex.StackTrace);
            }
        }
    }
}
