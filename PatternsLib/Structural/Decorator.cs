using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib.Structural
{
    public class DecoratorDemo
    {
        public void Show()
        {
            IComponent product;
            product = new CoffeeDecorator(null);
            product = new MilkDecorator(product);
            product = new ChocolateDecorator(product);
            product = new WaterDecorator(product);
            product = new SugarDecorator(product);
            Console.WriteLine(product.GetDescription());
            Console.WriteLine(product.GetPrice());

        }
    }
    interface IComponent
    {
        float GetPrice();
        String GetDescription(); // Название - кофе/сливки/сахар
    }



    class Coffee : IComponent
    {
        private float price;
        private String description;
        public Coffee()
        {
            description = "Coffee";
            price = 15;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Water : IComponent
    {
        private float price;
        private String description;
        public Water()
        {
            description = "Water";
            price = 5;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Sugar : IComponent
    {
        private float price;
        private String description;
        public Sugar()
        {
            description = "Sugar";
            price = 1;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Milk : IComponent
    {
        private float price;
        private String description;
        public Milk()
        {
            description = "Milk";
            price = 5;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }
    class Chocolate : IComponent
    {
        private float price;
        private String description;
        public Chocolate()
        {
            description = "Chocolate";
            price = 7;
        }
        public string GetDescription() => description;
        public float GetPrice() => price;
    }



    abstract class IDecorator : IComponent
    {
        protected IComponent wrappee;
        protected float price;
        protected string description;
        public IDecorator(IComponent wrappee)
        {
            this.wrappee = wrappee;
        }

        public String GetDescription()
        {
            string description = this.description;
            if (wrappee != null) description += wrappee.GetDescription();
            return description;
        }
        public float GetPrice()
        {
            float price = this.price;
            if (wrappee != null) price += wrappee.GetPrice();
            return price;

        }

    }



    class CoffeeDecorator : IDecorator
    {

        public CoffeeDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Coffee();
            description = component.GetDescription();
            price = component.GetPrice();
        }


    }

    class MilkDecorator : IDecorator
    {

        public MilkDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Milk();
            description = component.GetDescription();
            price = component.GetPrice();
        }


    }

    class ChocolateDecorator : IDecorator
    {

        public ChocolateDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Chocolate();
            description = component.GetDescription();
            price = component.GetPrice();
        }


    }

    class WaterDecorator : IDecorator
    {

        public WaterDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Water();
            description = component.GetDescription();
            price = component.GetPrice();
        }


    }

    class SugarDecorator : IDecorator
    {

        public SugarDecorator(IComponent wrappee) : base(wrappee)
        {
            IComponent component = new Sugar();
            description = component.GetDescription();
            price = component.GetPrice();
        }


    }
}
