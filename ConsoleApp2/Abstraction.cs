using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    abstract class Language
    {

        // abstract method
        public abstract void display1();

        // non-abstract method
        public void display2()
        {
            Console.WriteLine("Non abstract method");
        }
    }
    class Settings:Language
    {
        public override void display1()
        {
            // The body of animalSound() is provided here
            Console.WriteLine("abstract method from abstract class language");
        }
    }
}
