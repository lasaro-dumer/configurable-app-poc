using Configuration.Interfaces;
using System;

namespace Possible.Configuration.One
{
    public class OneStarter : IStarter
    {
        public IStandardOutput Output { get; }

        public OneStarter(IStandardOutput output)
        {
            Output = output;
        }
        
        public void Start(params object[] startParams)
        {
            if (startParams.Length < 1)
                throw new ArgumentException("The starter need at least one argument");
            else
                Output.Write("Starter starting....");
        }
    }
}
