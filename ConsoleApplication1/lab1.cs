using System;

namespace SimpleAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var analyzer = new Analyzer("c:/Program.txt");
            Token previousToken = null;

            while (analyzer.NextToken())
            {
                if (analyzer.CurrentToken is IdentifierToken && !(previousToken is CallToken)) continue;
                Console.WriteLine(analyzer.CurrentToken);
                previousToken = analyzer.CurrentToken;
            }
            Console.ReadKey();
        }
    }
}
