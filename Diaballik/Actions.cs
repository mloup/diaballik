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
            commandList.Add(command);
        }

        public Diaballik.Command pop()
        {
            Command ret = commandList.Last();
            commandList.Remove(commandList.Last());
            return ret;
        }

        public void set(Diaballik.Actions actionsList)
        {
            INSTANCE = actionsList;
        }
    }
}