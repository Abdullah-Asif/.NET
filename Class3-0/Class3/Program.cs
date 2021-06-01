using System;

namespace Class3
{
    class Program
    {
        delegate void Perform(string text);
        static void Main(string[] args)
        {
            var logic = new Perform(PrintingStyle2);
            var text = "Hello World";
            ProcessText(text, logic);

        }
        public static void PrintingStyle1(string text)
        {
            Console.WriteLine($"*** {text} ***");
        }
        public static void PrintingStyle2(string text)
        {
            Console.WriteLine($"--- {text} ---");
        }
         static void ProcessText(string text, Perform  perform)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                perform(text);
            }
        }
    }
}
