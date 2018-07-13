using System;

namespace UDHSkinTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating profile card !");
            ProfileCardGenerator gen = new ProfileCardGenerator();
            gen.GenerateProfileCard();
            Console.WriteLine("done");
        }
    }
}