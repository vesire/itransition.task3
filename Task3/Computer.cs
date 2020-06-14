using System;
using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    class Computer
    {
        public int pcMoveInt;
        public string pcMoveString;
        public byte[] key;
        public Computer(string[] args)
        {
            Random rnd = new Random();
            pcMoveInt = rnd.Next(args.Length);
            pcMoveString = args[pcMoveInt];
        }
        public byte[] CalculateHMAC()
        {
            key = GenerateKey();            
            byte[] messageInBytes = Encoding.ASCII.GetBytes(pcMoveString);
            HMACSHA256 hmac = new HMACSHA256(key);
            return hmac.ComputeHash(messageInBytes);
        }

        private byte[] GenerateKey()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] secretkey = new Byte[32];
            rng.GetBytes(secretkey);
            return secretkey;
        }
    }
}
