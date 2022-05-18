using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatternsLib
{

    public class ObserverDemo
    {
        private TextWriter _text_writer = new TextWriter();
        private SymbolCounter _symbol_counter = new SymbolCounter();
        private WordSearcher _word_searcher = new WordSearcher();
        private DigitCounter _digit_counter = new DigitCounter();

        public void Show()
        {
            ConsoleKeyInfo k;

            _text_writer.Subscribe(_symbol_counter);
            _text_writer.Subscribe(_word_searcher);
            _text_writer.Subscribe(_digit_counter);

            Console.WriteLine("Type smth");
            do
            {
                k = Console.ReadKey();

                _text_writer.State = _text_writer.State + k.KeyChar;
            } while (k.Key != ConsoleKey.Enter);
        }
    }
    interface IObserver
    {
        void Update(object state);
    }

    abstract class Subject
    {
        private List<IObserver> _observers;
        private object _state;

        public Subject()
        {
            _observers = new List<IObserver>();
            _state = null!;
        }

        public void Subscribe(IObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void Unubscribe(IObserver observer)
        {
            if (_observers.Contains(observer))
                _observers.Remove(observer);
        }

        public virtual void Notify(object arg = null!)
        {
            if (arg is null) 
                arg = this._state;
            
            foreach (IObserver obs in _observers)
                obs.Update(arg);
        }
    }

    class TextWriter : Subject
    {
        private String _state;

        public TextWriter() : base() => _state = String.Empty;

        public string State
        {
            set
            {
                _state = value;
                
                base.Notify(_state);
            }
            get => _state;
        }
    }

    class SymbolCounter : IObserver
    {
        public void Update(object state)
        {

            if (state is String str)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;

                Console.CursorLeft = 0;
                Console.CursorTop = 3;

                Console.Write($"cnt: {str.Length}");

                Console.CursorTop = top;
                Console.CursorLeft = left;
            }
            else 
                throw new ArgumentException("String expected");
        }
    }

    class WordSearcher : IObserver
    {
        public void Update(object state)
        {

            if (state is String str)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;

                Console.CursorLeft = 0;
                Console.CursorTop = 4;

                Console.Write($"Hi cnt: {Regex.Matches(str, "Hi").Count}");
                
                Console.CursorTop = top;
                Console.CursorLeft = left;
            }
            else 
                throw new ArgumentException("String expected");
        }
    }

    class DigitCounter : IObserver
    {
        public void Update(object state)
        {
            if (state is String str)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                
                Console.CursorLeft = 0;
                Console.CursorTop = 5;

                Console.Write($"Digit cnt: {Regex.Matches(str, "Hi").Count}");
                
                Console.CursorTop = top;
                Console.CursorLeft = left;
            }
            else 
                throw new ArgumentException("String expected");
        }
    }

  
}