using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class Originator
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("Enter employee: " + _state);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring person...");
            State = memento.State;
        }
    }

    public class Memento
    {
        private string _state;

        public Memento(string state)
        {
            this._state = state;
        }

        public string State
        {
            get { return _state; }
        }
    }

    public class Caretaker
    {
        private Memento _memento;

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}