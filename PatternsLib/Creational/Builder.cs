using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib
{
    public class BuilderDemo
    {
        public void Show()
        {
            DrinksBuilder builder = new CoffeeBuilder();
            Drinks? drinks;
            DrinkDirector drink_director;

            builder.SetMilk().SetShugar().SetSyrup();

            drinks = builder.Build();
            Console.WriteLine($"{drinks!.Description}");

            builder = new CacaoBuilder();
            builder.SetMilk().SetSyrup().SetChocolat().SetCinnamon();
            drinks = builder.Build();
            Console.WriteLine($"{drinks!.Description}");

            drink_director = new DrinkDirector(builder);
            drinks = drink_director.MakeaAmericano();
            Console.WriteLine($"{drinks!.Description}");

            drinks = drink_director.MakeEspresso();
            Console.WriteLine($"{drinks!.Description}");
        }
    }
    public abstract class Drinks
    {
        public string? Name { get; protected set; }
        public string? Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (HasMilk)
                    sb.Append("with milk ");
                if (HasShugar)
                    sb.Append("with shugar ");
                if (HasSyrup)
                    sb.Append("with syrup ");
                if (HasChocolat)
                    sb.Append("with chocolat ");
                if (HasCinnamon)
                    sb.Append("with cinnamon ");
                if (HasIce)
                    sb.Append("with ice ");
                if (Feature != String.Empty)
                    sb.Append(Feature);
                return sb.ToString();
            }
        }
        public bool HasMilk { get; set; } = false;
        public bool HasShugar { get; set; } = false;
        public bool HasSyrup { get; set; } = false;
        public bool HasChocolat { get; set; } = false;
        public bool HasCinnamon { get; set; } = false;
        public bool HasIce { get; set; } = false;
        public string Feature { get; set; } = String.Empty;
    }

    public abstract class DrinksBuilder
    {
        private Drinks? _drinks;

        public DrinksBuilder(Drinks drink) => _drinks = drink;

        public DrinksBuilder SetMilk()
        {
            _drinks!.HasMilk = true;
            return this;
        }
        public DrinksBuilder SetShugar() 
        {
            _drinks!.HasShugar = true;
            return this;
        }
        public DrinksBuilder SetSyrup() 
        {
            _drinks!.HasSyrup = true;
            return this;
        }
        public DrinksBuilder SetChocolat() 
        {
            _drinks!.HasChocolat = true;
            return this;
        }
        public DrinksBuilder SetCinnamon() 
        {
            _drinks!.HasCinnamon = true;
            return this;
        }
        public DrinksBuilder SetIce() 
        {
            _drinks!.HasIce = true;
            return this;
        }
        public Drinks? Build() { return _drinks; }
    }

    class CoffeeDrink : Drinks
    {
        public CoffeeDrink() { Name = "Coffee "; }
    }

    class CacaoDrink : Drinks
    {
        public CacaoDrink() { Name = "Cacao "; }
    }

    class CoffeeBuilder : DrinksBuilder
    {
        public CoffeeBuilder() : base(new CoffeeDrink()) { }
    }

    class CacaoBuilder : DrinksBuilder
    {
        public CacaoBuilder() : base(new CacaoDrink()) { }
    }

    class DrinkDirector
    {
        private readonly DrinksBuilder _drink_build;

        public DrinkDirector(DrinksBuilder drink_build) => _drink_build = drink_build;

        public Drinks MakeEspresso()
        {
            Drinks? drink = _drink_build.Build();

            drink!.Feature = "Espresso ";
            return drink;
        }

        public Drinks MakeaAmericano()
        {
            Drinks? drink = _drink_build.Build();

            drink!.Feature = "Americano ";
            return drink;
        }
    }

    
}
