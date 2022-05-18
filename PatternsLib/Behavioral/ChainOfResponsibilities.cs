using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib
{
    public class ChainOfResponsibilitiesDemo  // Forms a chain of handlers, and rebuilds it dynamically,
    {                                    // depending on the logic of the program.
        public void Show()
        {
            try
            {
                Manipulation coffee = new COFFEE();
                Manipulation coffee2 = new COFFEE();
                Manipulation boiling = new Boiling();
                Manipulation inserter = new COFFEEINSERTER();

                coffee.Next = boiling;
                boiling.Next = inserter;
                coffee.Execute(150);

                Console.WriteLine("------------------------");
                Console.Write("Volume: ");

                coffee2.SetNext(new Boiling())?.SetNext(new Shugar())?.SetNext(new Milk())?.SetNext(new COFFEEINSERTER());
                coffee2.Execute(Int32.Parse(Console.ReadLine()!));
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
        }
    }
    abstract class Manipulation  // The class has a field for storing a link 
    {                           // to the next handler in the chain.
        public Manipulation? Next { get; set; }  // Link to next handler.

        public Manipulation? SetNext(Manipulation next)  // Assigning a reference to the next object.
        {
            Next = next;
            return Next;
        }
        
        abstract public void Execute(int volume);  // Processing method.
    }

    // |  Сommented out.
    // V
    #region Links.
    class COFFEE : Manipulation  // Сontain request processing code COFFEE.
    {
        public override void Execute(int volume)  // Overrides the base method, 
        {                                        // outputs a description of the process, 
                                                // and defines a link to the next resource.
            Console.WriteLine("Coffee preparing starts...");
            Next?.Execute(volume);
        }
    }

    class Boiling : Manipulation   // Сontain request processing code Boiling.
    {
        public override void Execute(int volume)  // Overrides the base method, outputs a description of the process, 
        {                                        // and defines a link to the next resource. 
                                                // Determines if the variable takes a value above 300db - then throws an exception.
            if (volume > 300)
                throw new ArgumentException("Boiler capacity overload");

            Console.WriteLine("Water boiling starts...");
            Next?.Execute(volume);
        }
    }

    class Shugar : Manipulation  // Сontain request processing code Shugar.
    {
        public override void Execute(int volume)  // Overrides the base method, outputs a description of the process, 
        {                                        // and defines a link to the next resource.
            Console.WriteLine("Shugar starts...");
            Next?.Execute(volume);
        }
    }

    class Milk : Manipulation  // Сontain request processing code Milk.
    {
        public override void Execute(int volume)  // Overrides the base method, outputs a description of the process, 
        {                                        // and defines a link to the next resource with a value of + 50 percent increment.
            Console.WriteLine("Milk starts (adding 50ml)...");
            Next?.Execute(volume + 50);
        }
    }

    class COFFEEINSERTER : Manipulation  // The class describes the introduction of coffee.
    {
        public override void Execute(int volume)  // Overrides the base method, outputs a description of the process,
        {                                        // and defines a link to the next resource.
            Console.WriteLine("Coffee inserts...");
            Next?.Execute(volume);
        }
    }
    #endregion

   
}
