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
            {
                Console.ReadKey();
                return;
            }
            Computer pc = new Computer();
            Player player = new Player();
            while (true)
            {
                pc.Move(args);
                Console.WriteLine(String.Format("HMAC: {0}", HashEncode(pc.HMAC)));
                player.Move(args);
                if (player.ExitCondition())
                    break;
                ShowResults(player, pc, (args.Length - 1) / 2);
                Console.WriteLine(String.Format("HMAC key: {0}", HashEncode(pc.key)));
                Console.WriteLine();
            }
        }
        private static void ShowResults(Player player, Computer pc, int winningMoves)
        {
            Console.WriteLine(String.Format("Your move: {0}", player.playerMoveString));
            Console.WriteLine(String.Format("Computer move: {0}", pc.pcMoveString));
            if (player.playerMoveInt == pc.pcMoveInt)
                Console.WriteLine("Draw!");
            else
                Console.WriteLine(String.Format("{0} win!", WinnerDecider(player.playerMoveInt, pc.pcMoveInt, winningMoves)));
        }
        private static string WinnerDecider(int myMove, int pcMove, int winningMoves)
        {
            int moveDifference = myMove - pcMove;
            if ((moveDifference < (-winningMoves)) || (moveDifference > 0 && moveDifference <= winningMoves))
                return "You";
            return "Computer";
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