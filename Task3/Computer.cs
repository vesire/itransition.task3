﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    public class Computer
    {
        public int pcMoveInt { get; private set; } 
        public string pcMoveString { get; private set; }
        public byte[] key { get; private set; }
        public byte[] HMAC { get; private set; }
        public void Move(string[] args)
        {
            Random rnd = new Random();
            pcMoveInt = rnd.Next(args.Length);
            pcMoveString = args[pcMoveInt];
            HMAC = CalculateHMAC();
        }
        private byte[] CalculateHMAC()
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
