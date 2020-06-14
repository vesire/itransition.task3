using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Player
    {
        public int playerMoveInt;
        public string playerMoveString;
        public Player(string[] args)
        {
            int move;
            do
            {
                ShowMenu(args);
            } while (!int.TryParse(Console.ReadLine(), out move) || (move < 1 || move > args.Length));
            playerMoveInt = move - 1;
            playerMoveString = args[playerMoveInt];
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
