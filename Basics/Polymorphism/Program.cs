using System;
using System.Collections.Generic;

namespace Polymorphism
{
    class Program
    {
        static void Main()
        {
            var doggo = new Doggo();
            // will use the method of the inherited class because the method of the base class was hidden.
            doggo.Introduction();
            // will use the method of the inherited class because it was overridden.
            doggo.Greeting();

            //This is the actual polymorphism
            var Mammals = new List<Mammal>
            {
                new Ducky(),
                new Human()
            };
            foreach (var mammal in Mammals)
            {
                // will use the Method of the Base Class because this is implicit casted as type Mammal in List<Mammal>.
                mammal.Introduction();
                // will use the Method of the inherited Class because it was overridden.
                mammal.Greeting();
            }
        }
    }
    public class Mammal
    {
        public void Introduction()
        {
            Console.WriteLine("I am a Mammal");
        }
        public virtual void Greeting()
        {
            Console.WriteLine("I like to say:");
        }
    }
    public class Doggo : Mammal
    {
        public new void Introduction() // 'new' only hides the method of the base class
        {
            Console.WriteLine("I am a Doggo");
        }
        public override void Greeting() // 'override' overrides (duh!) the method of the base class
        {
            base.Greeting();
            Console.WriteLine("Woof!");
        }
    }
    public class Ducky : Mammal
    {
        public new void Introduction()
        {
            Console.WriteLine("I am a Ducky");
        }
        public override void Greeting()
        {
            base.Greeting();
            Console.WriteLine("Quack!");
        }
    }
    public class Human : Mammal
    {        
        public new void Introduction()
        {
            Console.WriteLine("I am a Human");
        }
        public override void Greeting()
        {
            base.Greeting();
            Console.WriteLine("Hello!");
        }
    }
}

/*
I am a Doogo
I like to say:
Woof!
I am a Mammal
I like to say:
Quack!
I am a Mammal
I like to say:
Hello!
*/