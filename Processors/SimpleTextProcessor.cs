using Configuration.Interfaces;

namespace Processors
{
    public class SimpleTextProcessor : ITextSplitter
    {
        public string[] SplitText(string text)
        {
            return text.Split();
        }
    }
}
