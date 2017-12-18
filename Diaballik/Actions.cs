using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class Actions
    {
        public static Actions INSTANCE = new Actions();
        private List<Command> cmdlist;

        private Actions()
        {
            cmdlist = new List<Command>();
        }

        ~Actions()
        {
            throw new System.NotImplementedException();
        }

        public List<Command> commandList
        {
            get => cmdlist;
            set
            {
                cmdlist = value;
            }
        }

        public void push(Diaballik.Command command)
        {
            throw new System.NotImplementedException();
        }

        public Diaballik.Command pop()
        {
            throw new System.NotImplementedException();
        }

        public void set(Diaballik.Actions actionsList)
        {
            throw new System.NotImplementedException();
        }
    }
}