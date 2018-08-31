using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Interfaces
{
    public interface ITextSplitter
    {
        string[] SplitText(string text);
    }
}
