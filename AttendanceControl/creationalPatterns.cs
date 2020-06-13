using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public interface IPosition
    {
        public void Greetings();
    }
    public class HumanDepartment : IPosition
    {
        public void Greetings()
        {
            Console.WriteLine("HumanDepartment");
        }
    }

    public class Guard : IPosition
    {
        public void Greetings()
        {
            Console.WriteLine("Guard");
        }
    }

    public class Employee : IPosition
    {
        public void Greetings()
        {
            Console.WriteLine("Employee");
        }
    }

    public class Inspector : IPosition
    {
        public void Greetings()
        {
            Console.WriteLine("Inspector");
        }
    }

    public interface ICreator
    {
        public IPosition FactoryMethod();
    }

    public class HumanDepartmentCreator : ICreator
    {
        public IPosition FactoryMethod()
        {
            return new HumanDepartment();
        }
    }

    public class GuardCreator : ICreator
    {
        public IPosition FactoryMethod()
        {
            return new Guard();
        }
    }

    public class EmployeeCreator : ICreator
    {
        public IPosition FactoryMethod()
        {
            return new Employee();
        }
    }

    public class InspectorCreator : ICreator
    {
        public IPosition FactoryMethod()
        {
            return new Inspector();
        }
    }
}