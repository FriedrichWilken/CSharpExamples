using System;
using System.Collections.Generic;

namespace Polymorphism
{
    class Program
    {
        static void Main()
        {
            var doggo = new Doggo {Name = "Pepe"};
            // will use the method of the inherited class because the method of the base class was hidden.
            doggo.Introduction();
            // will use the method of the inherited class because it was overridden.
            doggo.Greeting();

            //This is the actual polymorphism
            var Mammals = new List<Mammal>
            {
                new Ducky{Name = "Lauri"},
                new Human{Name = "Arvid"}
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
        public string Name;
        public void Introduction()
        {
            Console.WriteLine($"I am a Mammal, my name is {Name}");
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
            Console.WriteLine($"I am a Doggo, my name is {Name}");
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
            Console.WriteLine($"I am a Ducky, my name is {Name}");
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
            Console.WriteLine($"I am a Human, my name is {Name}");
        }
        public override void Greeting()
        {
            base.Greeting();
            Console.WriteLine("Hello!");
        }
    }
}

/*
I am a Doggo, my name is Pepe
I like to say:
Woof!
I am a Mammal, my name is Lauri
I like to say:
Quack!
I am a Mammal, my name is Arvid
I like to say:
Hello!
*/