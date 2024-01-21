using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15_Adapter.Problem
{
    public interface Animal
    {
        void Speak();
    }

    public class Cat : Animal
    {
        public void Speak(){
            Console.WriteLine("Meow...");
        }
    }

    public class Dog : Animal {
        public void Speak(){
            Console.WriteLine("Bark...");
        }
    }

    public interface AnimalToy {
        void MakeSound();
    }

    public class ToyDuck : AnimalToy {
        public void MakeSound(){
            Console.WriteLine("Squeak...");
        }
    }

    public class Application{ 
        public void TestToySound(AnimalToy animalToy)
        {
            animalToy.MakeSound();
        }
    }

    public class Client
    {
        public void DoStuff()
        {
            var c = new Cat();
            var d = new Dog();
            var td = new ToyDuck();

            var app = new Application();

            //app.TestToySound(c);
            //app.TestToySound(d);
            app.TestToySound(td);
        }
    }
}
