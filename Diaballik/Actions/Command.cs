using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class Command
    {
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public int NextX { get; set; }
        public int NextY { get; set; }

        public abstract void Do(Game g);

        public abstract bool CanDo(Game g);

        public abstract void Redo(Game g);

        public abstract void Undo(Game g);
        
        public abstract void Done();

        public abstract void IsDone();

        public Command Clone()
        {
            return MemberwiseClone() as Command;
        }
    }
}