using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Diaballik.Actors
{
    [Serializable]
    public abstract class Player
    {
        public string Color { get; set; }
        public String Name { get; set; }

        public Player(string n, string col)
        {
            Color = col;
            Name = n;
        }

        public override String ToString()
        {
            String res = "\t";
            res += this.GetType() + " named " + this.Name + " with color " + this.Color + "\n";
            return res;
        }
    }
}