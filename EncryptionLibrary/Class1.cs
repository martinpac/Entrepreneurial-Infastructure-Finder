using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public class Cryption
    {
        //key for encryption 
        byte[] seed = ASCIIEncoding.ASCII.GetBytes("Cse44598");

        //encrypt function, encrypts plain string
        public string Encrypt(string plainString)
        {
            //check if input is empty/null
            if (string.IsNullOrEmpty(plainString))
            {
                throw new ArgumentException("The input string for encryption cannot be null or empty");
            }

            //create DES encryption provider along with memory stream and crypto stream
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, saProvider.CreateEncryptor(seed, seed), CryptoStreamMode.Write);

            //streamwriter to write the plain string 
            StreamWriter sWriter = new StreamWriter(cStream);
            sWriter.Write(plainString);
            sWriter.Flush();
            cStream.FlushFinalBlock();

            //return encrypted base64 string
            return Convert.ToBase64String(mStream.GetBuffer(), 0, (int)mStream.Length);
        }

        //decrypt function, decrypts an encrypted string
        public string Decrypt(string encryptedString)
        {
            //check if input is empty/null
            if (string.IsNullOrEmpty(encryptedString))
            {
                throw new ArgumentException("The string for decryption cannot be null or empty");
            }

            //create DES decryption provider along with memory stream and crypto stream and stream reader
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream memStream = new MemoryStream(Convert.FromBase64String(encryptedString));
            CryptoStream cStream = new CryptoStream(memStream, saProvider.CreateDecryptor(seed, seed), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cStream);

            //return decrypted data as a string
            return reader.ReadLine();
        }
    }
}
