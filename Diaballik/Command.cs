using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class Command
    {
        public abstract void Do();

        public abstract bool CanDo();

        public abstract void Redo();

        public abstract void Undo();
    }
}