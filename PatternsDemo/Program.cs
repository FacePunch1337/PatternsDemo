using PatternsLib;
using PatternsLib.Behavioral;
using PatternsLib.Creational;
using PatternsLib.Structural;
using System;


namespace Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        static private void StartMenu()  // The method shows a menu of patterns.
        {
            String user_chois;

            while (true)
            {              // The menu of all patterns itself, the user can select one of them.
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("" +
                    "1[Creational]\n" +
                    "  1.1.Singleton\n" +
                    "  1.2.Simple Factory\n" +
                    "  1.3.Factory Method\n" +
                    "  1.4.Abstract Factory\n" +
                    "  1.5.Builder\n" +
                    "2[Behavioral]\n" +
                    "  2.1.Strategy\n" +
                    "  2.2.Observer\n" +
                    "  2.3.State\n" +
                    "  2.4.Chain of responsibilities\n" +
                    "3[Structural]\n" +
                    "  3.1.Decorator\n" +
                    "  3.2.Bridge\n" +
                    "  3.3.Proxy\n" +
                    "  3.4.Composite\n\n" +
                    "Chois: ");
                user_chois = Console.ReadLine()!;
                Console.Clear();

                switch (user_chois)
                {
                    case "1.1":
                        SINGLETON();
                        break;
                    case "1.2":
                        FACTORY();
                        break;
                    case "1.3":
                        FACTORYMETHOD();
                        break;
                    case "1.4":
                        ABSTRACTFACTORY();
                        break;
                    case "1.5":
                        BUILDER();
                        break;
                    case "2.1":
                        STRATEGY();
                        break;
                    case "2.2":
                        OBSERVER();
                        break;
                    case "2.3":
                        STATE();
                        break;
                    case "2.4":
                        CHAINOFRESPONSIBILITIES();
                        break;
                    case "3.1":
                        DECORATOR();
                        break;
                    case "3.2":
                        BRIGE();
                        break;
                    case "3.3":
                        PROXY();
                        break;
                    case "3.4":
                        COMPOZIT();
                        break;
                    default:
                        Console.WriteLine("No such number ;(");
                        break;
                }

                Console.Write("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region Patterns metods.   
        private static void SINGLETON()
        {
            Singleton obj = Singleton.GetInstance();
            Singleton obj2 = Singleton.GetInstance();

            Console.WriteLine(obj._moment);
            Console.WriteLine(obj == obj2 ? "Equals" : "No Equals");
        }

        private static void STRATEGY()
        {
            var StrategyDemo = new Strategy();

            StrategyDemo.Show();
            StrategyDemo.ShowDitails();
        }

        private static void DECORATOR() { new DecoratorDemo().Show(); }
        private static void FACTORY() { new FactoryDemo().Show(); }
        private static void FACTORYMETHOD() { new FactoryMethodDemo().Show(); }
        private static void ABSTRACTFACTORY() { new AbstractFactoryDemo().Show(); }
        private static void OBSERVER() { new ObserverDemo().Show(); }
        private static void BUILDER() { new BuilderDemo().Show(); }
        private static void BRIGE() { new BridgeDemo().Show(); }
        private static void PROXY() { new BridgeDemo().Show(); }
        private static void COMPOZIT() { new LinkerDemo().Show(); }
        private static void STATE() { new StateDemo().Show(); }
        private static void CHAINOFRESPONSIBILITIES() { new ChainOfResponsibilitiesDemo().Show(); }
        #endregion
    }
}