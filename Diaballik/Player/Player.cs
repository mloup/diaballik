using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class Player
    {
        public string Color { get; set; }
        public String Name { get; set; }

        public Player(string n, string col)
        {
            Color = col;
            Name = n;
        }
    }
}