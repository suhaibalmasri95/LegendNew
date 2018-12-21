using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Auth
{
    public static class Encryption
    {
        public static string EncryptPassword(string Content)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider M5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] ByteString = System.Text.Encoding.ASCII.GetBytes(Content);
            ByteString = M5.ComputeHash(ByteString);
            string FinalString = null;
            foreach (byte bt in ByteString)
            {
                FinalString += bt.ToString("x2");
            }
            string encrypted = FinalString.ToUpper();
            return encrypted;
        }
    }
}
