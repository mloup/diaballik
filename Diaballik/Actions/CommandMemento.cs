using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class CommandMemento
    {
        public Command _cmd;

        public CommandMemento(Command c)
        {
            _cmd = c.Clone();
        }

        public Command GetCommand()
        {
            return _cmd;
        }
    }
}
