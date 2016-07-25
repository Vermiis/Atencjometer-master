using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace ConnectToWypok
{







    class toMD5
    {

        //md5("MNOPQRST" + "http://a.wykop.pl/entries/add/appkey/abcdefgh/userkey/klucz_zalogowanego_użytkownika/" 
        //+ "przykładowy komentarz,http://serwer/plik.jpg") = c1048ea53bdf3d60383b033c5d97f8c1


        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
















        //public string GetHashMD5 (string a)
        //{
        //    string source = "Hello World!";
        //    using (MD5 md5Hash = MD5.Create())
        //    {
        //        string hash = GetMd5Hash(md5Hash, source);

        //        Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

        //        Console.WriteLine("Verifying the hash...");

        //        if (VerifyMd5Hash(md5Hash, source, hash))
        //        {
        //            Console.WriteLine("The hashes are the same.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("The hashes are not same.");
        //        }
        //}
    }
}
