using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib
{
    public class Strategy
    {
        private MeanCalculator _mean_calculator;
        private List<double> _data = new List<double>() { 1, 2, 3, 4, 5 };

        public Strategy()
        {
            _mean_calculator = new MeanCalculator();

            _mean_calculator._strategies!.Add(new MeanArithmetic());
            _mean_calculator._strategies.Add(new MeanHarmonic());
            _mean_calculator._strategies.Add(new MeanGeometric());
            _mean_calculator._strategies.Add(new MeanProgressive());
        }

        public void Show()
        {
            Console.WriteLine("  { Means } ");
            foreach (var mean in _mean_calculator!.GetAll(_data))
                Console.WriteLine(mean);

            Console.WriteLine($"Greatest: {_mean_calculator.GetGreatest(_data)}");
        }

        public void ShowDitails()
        {
            Console.WriteLine("\n { Deteils } ");
            foreach (IMeanValue strategy in _mean_calculator!._strategies!)
                Console.WriteLine($"\tAlgo: {strategy.GetType().Name} / Value: {strategy.GetMean(_data)}");
        }
    }

    interface IMeanValue
    {
        public double GetMean(List<double> arr);
    }

    #region Types of strategies.
    class MeanArithmetic : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 0;
            int n = arr.Count;

            foreach (var item in arr)
                ret += item / n;

            return ret;
        }
    }

    class MeanHarmonic : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 0;
            int n = arr.Count;

            foreach (var item in arr)
                ret += 1 / n;

            return n / ret;
        }
    }

    class MeanGeometric : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 1;
            int n = arr.Count;

            foreach (var item in arr)
                ret *= item;

            return Math.Pow(ret, 1.0 / n);
        }
    }

    class MeanProgressive : IMeanValue
    {
        public double GetMean(List<double> arr)
        {
            double ret = 1;
            int n = arr.Count;

            foreach (var item in arr)
                ret += item / n;      

            return ret;
        }
    }
    #endregion

    class MeanCalculator
    {
        public List<IMeanValue>? _strategies = new List<IMeanValue>();

        public double GetGreatest(List<double> arr) { return GetAll(arr).Max(); }

        public List<double> GetAll(List<double> arr)
        {
            List<double> ret = new List<double>();

            foreach(IMeanValue strategy in _strategies!)
                ret.Add(strategy.GetMean(arr));

            return ret;
        }
    }
    
   
}