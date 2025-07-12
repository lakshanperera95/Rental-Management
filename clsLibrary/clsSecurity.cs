using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
namespace clsLibrary
{
    public class clsSecurity
    {

        ///*
        //private static string sKey = "UJYHCX783her*&5@$%#(MJCX**38n*#6835ncv56tvbry(&#MX98cn342cn4*&X#&";
        private static string sKey = "UJYHCX783her*&5@$%#(PQRS**38n*#6835ert56tvbry(&#ST98cn342cn4*&X#&";
        public static string Encrypt(string sPainText)
        {
            if (sPainText.Length == 0)
                return (sPainText);
            return (EncryptString(sPainText, sKey));
        }

        public static string Decrypt(string sEncryptText)
        {
            if (sEncryptText.Length == 0)
                return (sEncryptText);
            return (DecryptString(sEncryptText, sKey));
        }
        //*


        protected static string EncryptString(string InputText, string Password)
        {
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainText, 0, PlainText.Length);
                cryptoStream.FlushFinalBlock();
                byte[] CipherBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string EncryptedData = Convert.ToBase64String(CipherBytes);
                return EncryptedData;
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        protected static string DecryptString(string InputText, string Password)
        {
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] EncryptedData = Convert.FromBase64String(InputText);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                byte[] PlainText = new byte[EncryptedData.Length];

                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();

                string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);

                return DecryptedData;
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    }
}
