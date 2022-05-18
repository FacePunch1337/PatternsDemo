using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib.Creational
{
    public class FactoryMethodDemo
    {
        public void Show()
        {
            IDialog TheDialog1;
            TheDialog1 = new DialogOne();
            IButton TheBotton1 = TheDialog1.MakeButton();
            Console.WriteLine(TheBotton1.Render());
            TheBotton1.Click();

            IDialog TheDialog2;
            TheDialog2 = new DialogTwo();
            IButton TheBotton2 = TheDialog2.MakeButton();
            Console.WriteLine(TheBotton2.Render());
            TheBotton2.Click();



        }




        interface IDialog
        {
            IButton MakeButton();

        }

        class DialogOne : IDialog
        {
            public IButton MakeButton()
            {
                return new ButtonOne(this);
            }

            public void Show()
            {
                Console.WriteLine("ButtonOne");

            }
        }

        class DialogTwo : IDialog
        {
            public IButton MakeButton()
            {
                return new ButtonTwo(this);
            }
            public void Show()
            {
                Console.WriteLine("ButtonTwo");

            }
        }


        interface IButton
        {
            String Render();
            void Click();

        }

        class ButtonOne : IButton
        {
            private DialogOne dialog;
            public ButtonOne(DialogOne dialog)
            {
                this.dialog = dialog;
            }
            public String Render()
            {
                return "<<Button One>>";
            }
            public void Click()
            {
                dialog.Show();
            }
        }

        class ButtonTwo : IButton
        {
            private DialogTwo dialog;
            public ButtonTwo(DialogTwo dialog)
            {
                this.dialog = dialog;
            }
            public String Render()
            {
                return "[[Button Two]]";
            }

            public void Click()
            {
                dialog.Show();
            }
        }


    }
}

