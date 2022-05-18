using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib
{
    interface IFigureComponent  // All devices share a common interface.
    {
        void Render();  
    }

    class Figure  // An abstraction contains control logic.
    {            // The abstraction code delegates the actual work to the associated implementation object.
        private List<IFigureComponent> _components;

        public Figure() => _components = new List<IFigureComponent>();

        public Figure AddComponent(IFigureComponent component)  // Adds data about the figure, has the ability to
        {                                                      // implement a fluid interface in the client code.
            _components.Add(component);
            return this;
        }

        public void Render()  // Overriding the shape output method.
        {
            if (_components.Count == 0)
                Console.WriteLine("**👻**");
            else
            {
                foreach (IFigureComponent component in _components)
                    component.Render();
            }

        }
    }

    class ShapeComponent : IFigureComponent  // Extended abstractions contain various variations of 
    {                                       // the control logic Shape.
        private readonly String _shape;

        public ShapeComponent(string shape) => _shape = shape;

        public void Render() => Console.Write($" {_shape} ");  // Overriding the shape output method.
    }

    class StrokeComponent : IFigureComponent  // Extended abstractions contain various variations of 
    {                                        // the control logic Stroke.
        private readonly String _color;
        private readonly int _width;

        public StrokeComponent(string color, int width)
        {
            _color = color;
            _width = width;
        }

        public void Render() => Console.Write($" {_color} border {_width}px ");  // Overriding the shape output method.
    }

    class FillComponent : IFigureComponent  // Extended abstractions contain various variations 
    {                                      // of the control logic Fill.
        private readonly String _color;
        private readonly String _style;

        public FillComponent(string color, string style)
        {
            _color = color;
            _style = style;
        }

        public void Render() => Console.Write($" fill {_color} style {_style}");  // Overriding the shape output method.
    }

    class ShadowComponent : IFigureComponent  // Extended abstractions contain various variations of 
    {                                        // the control logic Shadow.
        private int _x;
        private int _y;
        private uint _blur;

        public ShadowComponent(int off_setX, int off_setY, uint blur)
        {
            _x = off_setX;
            _y = off_setY;
            _blur = blur;
        }

        public void Render() => Console.Write($" COORD[{_x},{_y}] blure {_blur}%");  // Overriding the shape output method.
    }

    public class BridgeDemo  // Client works only with abstraction objects. Apart from the initial 
    {                   // binding of the abstraction to one of the implementations,
                                // the client code has no direct access to the implementation objects.
        public void Show()
        {
            Figure f1 = new Figure();
            Figure f2 = new Figure();
            Figure f3 = new Figure();

            f1.AddComponent(new ShapeComponent("Circle"));
            f1.AddComponent(new StrokeComponent("lime", 69));
            f1.AddComponent(new FillComponent("lime", "modern"));
            f1.Render();

            Console.WriteLine();

            f2.AddComponent(new ShapeComponent("Diamond"))
                .AddComponent(new FillComponent("Cold", "Solid"));
            f2.Render();

            Console.WriteLine();

            f3.AddComponent(new ShapeComponent("Cylinder")).AddComponent(new StrokeComponent("Tiffany", 69))
                .AddComponent(new ShadowComponent(34, 55, 80));
            f3.Render();
        }
    }
}