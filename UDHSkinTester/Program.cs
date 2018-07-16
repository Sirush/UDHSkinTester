using System;
using System.Diagnostics;

namespace UDHSkinTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating profile card !");
            ProfileCardGenerator gen = new ProfileCardGenerator();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            gen.GenerateProfileCard();
            stopwatch.Stop();
            Console.WriteLine($"Image generation took : {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine("done");
        }
    }
}