using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PatternsLib
{
    public class Singleton
    {
        public DateTime _moment = DateTime.Now;
        private static Singleton? _instance;

        private Singleton()
        {
            _instance = null!;
        }

        public static Singleton Instance { get { return _instance!; } }

        public static Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new Singleton();
            
            return _instance;
        }
    }
}