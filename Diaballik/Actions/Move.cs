using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.Actions
{
    public abstract class Move : Command
    {
        protected Move(int x1, int y1, int x2, int y2)
        {
            PrevX = x1;
            PrevY = y1;
            NextX = x2;
            NextY = y2;
        }

        public int PrevX { get; }
        public int PrevY { get; }
        public int NextX { get; }
        public int NextY { get; }

        public override String ToString()
        {
            String res = "\t\t" + this.GetType() + " : from (" + PrevX + ", " + PrevY + ") to (" + NextX + ", " + NextY + ")\n";
            return res;
        }
    }
}
