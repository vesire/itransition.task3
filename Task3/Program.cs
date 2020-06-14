using System;
using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            if (!CheckArgs(args))
                return;
            Computer pc = new Computer(args);
            byte[] pcMoveHMAC = pc.CalculateHMAC();
            Console.WriteLine(String.Format("HMAC: {0}", HashEncode(pcMoveHMAC)));
            Player player = new Player(args);
            ShowResults(player, pc, (args.Length - 1) / 2);
            Console.WriteLine(String.Format("HMAC key: {0}", HashEncode(pc.key)));
        }
        private static void ShowResults(Player player, Computer pc, int numberOfWinningMoves)
        {
            Console.WriteLine(String.Format("Your move: {0}", player.playerMoveString));
            Console.WriteLine(String.Format("Computer move: {0}", pc.pcMoveString));
            if (player.playerMoveInt == pc.pcMoveInt)
                Console.WriteLine("Draw!");
            else
                Console.WriteLine(String.Format("{0} win!", WinnerDecider(player.playerMoveInt, pc.pcMoveInt, numberOfWinningMoves)));
        }
        private static string WinnerDecider(int myMove, int pcMove, int numberOfWinningMoves)
        {
            string winner;
            int moveDifference = myMove - pcMove;
            if ((moveDifference < (-numberOfWinningMoves)) || (moveDifference > 0 && moveDifference <= numberOfWinningMoves))
                winner = "You";
            else
                winner = "Computer";
            return winner;
        }
        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
        private static bool CheckArgs(string[] args)
        {
            bool fitsConditions = true;
            if (args.Length % 2 == 0 || args.Length < 3)
            {
                Console.WriteLine("Error, invalid number of arguments!");
                fitsConditions = false;
            }
            for (int i = 0; i < args.Length - 1; i++)
                for (int j = i + 1; j < args.Length; j++)
                    if (args[i] == args[j])
                    {
                        Console.WriteLine("Error, two or more arguments are equal!");
                        fitsConditions = false;
                        break;
                    }
            return fitsConditions;
        }
    }
}