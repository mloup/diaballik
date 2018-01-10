using Diaballik.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    [Serializable]
    public abstract class Command
    {
        public abstract void Do(Game g);

        public abstract bool CanDo(Game g);

        public abstract void Undo(Game g);

        public abstract bool CanUndo(Game g);

        public Command Clone() // TO FIX
        {
            return MemberwiseClone() as Command;
        }
    }
}