using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib.Creational
{
    public class AbstractFactoryDemo
    {
         
        public void Show()
        {
            ICrypterAbstractFactory factory = new AESFactory();
            ICryptoHasher hasher = factory.GetHasher();
            Console.WriteLine(hasher.Hash("test"));
            ICryptoCipher cipher = factory.GetCipher();
            Console.WriteLine(cipher.Cipher("test"));
        }
    }

    interface ICryptoHasher
    {
        String Hash(String input);
    }

    interface ICryptoCipher
    {
        String Cipher(String input);
    }

    interface ICryptoDecipher
    {
        String Decipher(String input);
    }

    interface ICrypterAbstractFactory
    {
        ICryptoHasher GetHasher();
        ICryptoCipher GetCipher();
        ICryptoDecipher GetDecipher();
    }

    ////////////////DSTU/////////////////////

    class DSTUHasher : ICryptoHasher
    {
        public String Hash(String input)
        {
            return $"Kupina hash of '{input}'";
        }
    }

    class DSTUCipher : ICryptoCipher
    {
        public String Cipher(String input)
        {
            return $"Kalina cipher of '{input}'";
        }
    }

    class DSTUDecipher : ICryptoDecipher
    {
        public String Decipher(String input)
        {
            return $"Kalina decipher of '{input}'";
        }
    }

    class DTSUFactory : ICrypterAbstractFactory
    {
        public ICryptoCipher GetCipher()
        {
            return new DSTUCipher();
        }

        public ICryptoDecipher GetDecipher()
        {
            return new DSTUDecipher();
        }

        public ICryptoHasher GetHasher()
        {
            return new DSTUHasher();
        }
    }
    /////////////AES////////////////
    class AESHasher : ICryptoHasher
    {
        public String Hash(String input)
        {
            return $"SHA hash of '{input}'";
        }
    }

    class AESCipher : ICryptoCipher
    {
        public String Cipher(String input)
        {
            return $"AES cipher of '{input}'";
        }
    }

    class AESDecipher : ICryptoDecipher
    {
        public String Decipher(String input)
        {
            return $"AES decipher of '{input}'";
        }
    }

    class AESFactory : ICrypterAbstractFactory
    {
        public ICryptoCipher GetCipher()
        {
            return new AESCipher();
        }

        public ICryptoDecipher GetDecipher()
        {
            return new AESDecipher();
        }

        public ICryptoHasher GetHasher()
        {
            return new AESHasher();
        }
    }

}


