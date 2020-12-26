using System;

namespace EventExample
{
    class Program
    {
        static void Main()
        {
            Parent parent = new();
            parent.Child.DoSomething();
        }
    }
    public class Parent
    {
        public Parent()
        {
            Child = new();
            Child.ChildEvent += Child_OnEvent;
        }
        public Child Child;

        private void Child_OnEvent(object sender, System.EventArgs e)
        {
            Console.WriteLine("Partent gets notified.");
        }
    }
    public class Child
    {
        public void DoSomething()
        {
            Console.WriteLine("Child does something.");
            OnEvent();
        }
        public event EventHandler ChildEvent;
        // This uses 1 of C#'s 2 build-in event handlers:
        // 1. EventHandler(object sender, EventArgs e);
        // 2. EventHandler<TEventArgs>(object sender, TEventArgs e)
        // But you could also build your own.
        // https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-raise-and-consume-events
        public void OnEvent()
        {
            Console.WriteLine("Child's event gets triggert.");
            ChildEvent?.Invoke(
                sender: this,
                e: EventArgs.Empty);
        }
    }
}

/*
Child does something.
Child's event gets triggert.
Partent gets notified.
*/