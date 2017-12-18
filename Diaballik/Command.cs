using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class Command
    {
        public abstract void @do();

        public abstract bool canDo();

        public abstract void redo();

        public abstract void undo();
    }
}