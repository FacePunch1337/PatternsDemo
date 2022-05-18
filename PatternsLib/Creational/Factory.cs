using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib.Creational
{
    public class FactoryDemo
    {
        public void Show()
        {
            Console.WriteLine("Wich algo?");
            String algo = Console.ReadLine();
            try
            {
                IHasher hasher = CryptoFactory.GetInstace(algo);
                Console.WriteLine(hasher.Hash("content"));
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message + "💩");
            }
        }
    }



    interface IHasher
    {
        String Hash(String s);
    }

    class Md5Hasher : IHasher
    {
        public String Hash(string s)
        {
            return $"MD5 hash of {s}";
        }
    }
    class Sha1Hasher : IHasher
    {
        public String Hash(string s)
        {
            return $"SHA-1 hash of {s}";
        }
    }

    class Sha2Hasher : IHasher
    {
        public String Hash(string s)
        {
            return $"SHA-2 hash of {s}";
        }
    }

    class KupinaHasher : IHasher
    {
        public String Hash(string s)
        {
            return $"Kupina-256 hash of {s}";
        }
    }

    class CryptoFactory
    {
        public static IHasher GetInstace(String algoName)
        {
            switch (algoName)
            {
                case "MD5":
                case "MD-5":
                case "Md5":
                    return new Md5Hasher();
                case "SHA1":
                case "SHA-1":
                case "SHA-160":
                    return new Sha1Hasher();
                case "SHA2":
                case "SHA-2":
                case "SHA-256":
                    return new Sha2Hasher();
                case "Kupina":
                case "DSTU":
                case "DSTU-256":
                    return new KupinaHasher();
                default:
                    throw new ArgumentException($"Algo '{algoName}' invalid");

            }
        }
    }
}

