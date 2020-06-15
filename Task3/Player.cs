using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Player
    {
        public int playerMoveInt { get; private set; }
        public string playerMoveString { get; private set; }
        public void Move(string[] args)
        {
            int move;
            do
            {
                ShowMenu(args);
            } while (!int.TryParse(Console.ReadLine(), out move) || (move < 0 || move > args.Length));
            playerMoveInt = move - 1;
            if(!ExitCondition())
                playerMoveString = args[playerMoveInt];
        }
        public bool ExitCondition()
        {
            if (playerMoveInt == -1)
                return true;
            return false;
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
