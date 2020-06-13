using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // creation pattern lab 10
            ICreator[] creators = { new HumanDepartmentCreator(), new GuardCreator(), new EmployeeCreator(), new InspectorCreator() };
            foreach (ICreator creator in creators)
            {
                IPosition position = creator.FactoryMethod();
                position.Greetings();
            }


            // structural pattern 11
            Pass pass = new Adapter();
            pass.ScreenSay();


            // behaviour pattern Memento 12
            Originator o = new Originator();
            Caretaker c = new Caretaker();
            o.State = "Ivanenko Stepan";
            c.Memento = o.CreateMemento();
            o.State = "Stepanenko Ivan";
            c.Memento = o.CreateMemento();
            o.State = "Vasylenko Olexandr";
            o.SetMemento(c.Memento);

            Console.Read();
        }
    }
}