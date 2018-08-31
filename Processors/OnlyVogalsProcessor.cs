using Configuration.Interfaces;
using System.Collections.Generic;

namespace Processors
{
    public class OnlyVogalsProcessor : ITextSplitter
    {
        public string[] SplitText(string text)
        {
            List<string> result = new List<string>();
            List<char> vogals = new List<char>() { 'A', 'E', 'I', 'O', 'U' };

            text = text.ToUpper();

            for (int i = 0; i < text.Length; i++)
                if (vogals.Contains(text[i]))
                    result.Add(text[i].ToString());

            return result.ToArray();
        }
    }
}
