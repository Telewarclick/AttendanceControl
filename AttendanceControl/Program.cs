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

            Console.Read();
        }
    }
}