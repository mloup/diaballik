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

        public abstract void Do();

        public abstract bool CanDo();

        public abstract void Undo();

        public Command Clone()
        {
            return MemberwiseClone() as Command;
        }
    }
}