using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public abstract class Worker
    {
        public Worker Employee { get; private set; }
        protected Worker(Worker worker)
        {
            Employee = worker;
        }
        public virtual void HandleJob(Job job)
        {
            if (Employee != null)
            {
                Employee.HandleJob(job);
            }
        }
    }

    public class Housemaid : Worker
    {
        public List<Job> Jobs { get; private set; }
        public Housemaid(Worker worker) : base(worker)
        {
            Jobs = new List<Job>();
        }
        public override void HandleJob(Job job)
        {
            if (job.Name.Contains("Dry"))
            {
                Console.WriteLine(
                "Housemaid: My work is {0}.",
                job.Name);
                return;
            }
            base.HandleJob(job);
        }
    }

    public class Locksmith : Worker
    {
        public Locksmith(Worker worker) : base(worker)
        {
        }
        public override void HandleJob(Job job)
        {
            if (job.Tools.Contains("Key") || job.Tools.Contains("Bearing"))
            {
                Console.WriteLine("Locksmith: I go to {0}", job.Name);
                return;
            }


            base.HandleJob(job);
        }
    }

    public class Welder : Worker
    {
        public Welder(Worker worker) : base(worker)
        {
        }
        public override void HandleJob(Job job)
        {
            if (job.Name.Contains("Brew") || job.Tools.Contains("Welding machine"))
            {
                Console.WriteLine("Welder: {0}. This is work for me.", job.Name);
                return;
            }

            base.HandleJob(job);
        }
    }

    public class Job
    {
        public string Name;
        public List<string> Tools;

        public Job(string name, List<string> tools)
        {
            Name = name;
            Tools = tools;
        }
    }
}