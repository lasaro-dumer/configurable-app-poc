using Configuration.Interfaces;
using System;

namespace Configuration.Output
{
    public class ConsoleOutput : IStandardOutput
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
