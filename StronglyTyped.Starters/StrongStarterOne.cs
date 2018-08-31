using Configuration.Interfaces;
using Domain.Types.One;
using System;

namespace StronglyTyped.Starters
{
    public class StrongStarterOne : IStarter
    {
        public IStandardOutput Output { get; }

        public StrongStarterOne(IStandardOutput output)
        {
            Output = output;
        }

        public void Start(params object[] startParams)
        {
            if (startParams.Length < 1)
            {
                throw new ArgumentException("The starter need at least one argument");
            }
            else
            {
                if (startParams[0] is OneIntegerThingy intThingy)
                {
                    Output.Write("Received params:");
                    foreach (var param in startParams)
                    {
                        Output.Write(param.ToString());
                    }
                }
                else
                {
                    throw new ArgumentException($"The starter need a {nameof(OneIntegerThingy)}");
                }
            }
        }
    }
}
