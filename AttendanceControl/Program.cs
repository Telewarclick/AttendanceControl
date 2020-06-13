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


            // chain responsibility pattern 13
            var task1 = new Job("Dry oil around engine", new List<string> { "Rag", "Gas", "Mop" });
            var task2 = new Job("Dry flor around circulating pump", new List<string> { "Rag", "Mop" });
            var task3 = new Job("Change bearing", new List<string> { "Bearing", "Oil" });
            var task4 = new Job("Brew a gap in circulating pump", new List<string> { "Welding machine" });
            var task5 = new Job("Repair engine", new List<string> { "Key", "Bearing", "Oil" });
            var locksmith = new Locksmith(null);
            var welder = new Welder(locksmith);
            var housemaid = new Housemaid(welder);
            housemaid.HandleJob(task1);
            housemaid.HandleJob(task2);
            housemaid.HandleJob(task3);
            housemaid.HandleJob(task4);
            housemaid.HandleJob(task5);

            Console.Read();
        }
    }
}