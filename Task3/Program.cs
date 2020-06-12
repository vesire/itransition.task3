using System;
using System.Security.Cryptography;

namespace Task3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            if (args.Length % 2 == 0 || args.Length < 3)
                Console.WriteLine("Error, otsosi");
            Random rnd = new Random();
            int pcMove = rnd.Next(args.Length);
            Console.WriteLine(pcMove);
            int myMove;
            do
            {
                ShowMenu(args);
            } while (!int.TryParse(Console.ReadLine(), out myMove) || (myMove < 1 || myMove > args.Length));

            //Console.WriteLine(args[pcMove]);
            Console.ReadLine();
        }

        private static void ShowMenu(string[] args)
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine(String.Format("{0} - {1}", i + 1, args[i]));
            Console.WriteLine("0 - exit");
            Console.Write("Enter your move:");
        }
    }
}
