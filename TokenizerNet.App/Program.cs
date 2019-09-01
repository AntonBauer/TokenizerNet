using System;
using System.Linq;
using TokenizerNet.PropertiesFileParsers;

namespace TokenizerNet.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new PropertiesParser();
            var symbols = parser.Parse(@"c:\Development\Personal\TokenizerNet\Data\WordBreakProperty.txt").ToList();
        }
    }
}
