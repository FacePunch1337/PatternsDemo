using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib
{

    public class LinkerDemo  // Shows the full power of the linker pattern.
    {
        public void Show()
        {
            Firm firm = new Firm();

            firm.Members!.Add(new FinDerector());
            firm.Members!.Add(new ExeDerector());
            firm.Members!.Add(new LabourUnion());
            firm.Members!.Add(new DivisionsDelegate());
            firm.MakeResolution("Bake a cookie");
        }
    }
    interface IMember  // Common interface for simple and composite tree components.
    {
        void TakeResolution(String resolution);
    }

    class Firm  // The client works with the tree through the common interface of the components.  
    {          // Due to this, the client does not care what is in front of him - a simple   
               // or a composite component of the tree.
        public List<IMember>? Members { get; set; }

        public Firm() => Members = new List<IMember>();

        public void MakeResolution(string resolution)
        {
            Console.WriteLine($"\n{Members!.Count} Firm make resolution");
            foreach (IMember item in Members!)
                item.TakeResolution(resolution);
        }
    }

    class FinDerector : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"FinDerector take '{resolution}'");
    }

    class ExeDerector : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"ExeDerector take '{resolution}'");
    }

    #region Complex member.
    //-----------------------------------Complex member-----------------------------------
    abstract class CompositMember : IMember  // Contains a set of child components, but knows nothing about their types.
    {                                       //  These can be either simple leaf components or other container components.
        public List<IMember>? Members { get; set; }

        public abstract void TakeResolution(string resolution);
    }

    class BakersDelegate : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"BakersDelegate take '{resolution}'");
    }

    class CleaningsDelegate : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"CleaningsDelegate take '{resolution}'");
    }

    class LoadersDelegate : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"LoadersDelegate take '{resolution}'");
    }

    class LabourUnion : CompositMember  //  These can be either simple leaf components or other container components.
    {
        public LabourUnion()
        {
            Members = new List<IMember>() { new BakersDelegate(), new CleaningsDelegate(), new LoadersDelegate() };
        }

        override public void TakeResolution(string resolution)
        {
            Console.WriteLine($"\n{Members!.Count} LabourUnion take resolution");
            foreach (IMember item in Members!)
            {
                Console.Write(" [*] ");
                item.TakeResolution(resolution);
            }
        }
    }

    class DivisionsDelegate : CompositMember  //  These can be either simple leaf components or other container components.
    {
        public DivisionsDelegate()
        {
            Members = new List<IMember>() { new KhersonDelegate(), new MykolaivDelegate(), new OdessaDelegate() };
        }

        override public void TakeResolution(string resolution)
        {
            Console.WriteLine($"\n{Members!.Count} DivisionsDelegate take resolution");
            foreach (IMember item in Members!)
            {
                Console.Write(" [*] ");
                item.TakeResolution(resolution);
            }
        }
    }

    class MykolaivDelegate : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"MykolaivDelegate take '{resolution}'");
    }

    class KhersonDelegate : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"KhersonDelegate take '{resolution}'");
    }

    class OdessaDelegate : CompositMember  //  These can be either simple leaf components or other container components.
    {
        public OdessaDelegate()
        {
            Members = new List<IMember>() { new IzmailDelegate(), new AkermanDelegate() };
        }

        override public void TakeResolution(string resolution)
        {
            Console.WriteLine($"{Members!.Count} OdessaDelegate take resolution '{resolution}'");
            foreach (IMember item in Members!)
            {
                Console.Write(" [*] [*] ");
                item.TakeResolution(resolution);
            }
        }
    }

    class AkermanDelegate : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"Akerman take '{resolution}'");
    }

    class IzmailDelegate : IMember  // A tree component that has no branches.
    {
        public void TakeResolution(string resolution) => Console.WriteLine($"Izmail take '{resolution}'");
    }
    #endregion

   
}
