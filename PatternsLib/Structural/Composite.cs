using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patternss.StructuralPatterns
{
    internal class CompositeDemo
    {
        public void Show()
        {
            Firm firm = new Firm();
            firm.Members.Add(new FinDirector());
            firm.Members.Add(new ExeDirector());

            firm.MakeResolution("Bake a cookie");
        }
    }

    interface IMember
    {
        void TakeResolution(String resolution);
    }

    class FinDirector : IMember
    {
        public void TakeResolution(string resolution)
        {
            Console.WriteLine($"FinDirector take '{resolution}' ");
        }
    }

    class ExeDirector : IMember
    {
        public void TakeResolution(string resolution)
        {
            Console.WriteLine($"ExeDirector take '{resolution}' ");
        }
    }

    class Firm
    {
        public List<IMember> Members { get; set; }

        public Firm()
        {
            Members = new List<IMember>();
        }
        public void MakeResolution(String resolution)
        {
            Console.WriteLine($"Firm make resolution '{resolution}'");
            foreach (IMember member in Members)
            {
                member.TakeResolution(resolution);
            }
        }
    }

    ////////////////////////////-Complex Member-/////////////////////////////

    class BakerDelegate : IMember
    {
        public void TakeResolution(string resolution)
        {
            Console.WriteLine($"BakersDelegate take '{resolution}' ");
        }
    }

    class CleaningsDelegate : IMember
    {
        public void TakeResolution(string resolution)
        {
            Console.WriteLine($"CleaningsDelegate take '{resolution}' ");
        }
    }

    class LoadersDelegate : IMember
    {
        public void TakeResolution(string resolution)
        {
            Console.WriteLine($"CleaningsDelegate take '{resolution}' ");
        }
    }
    class LabourUnion
    {
        public List<IMember> Members { get; set; }
    }
}
