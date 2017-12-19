using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class BuilderGame
    {
        private string name1;
        private string name2;
        private string color1;
        private string color2;
        private IAStrategy strat;
        private bool hasIA;

        public string Name1
        {
            get => name1;
            set
            {
                name1 = value;
            }
        }

        public string Name2
        {
            get => name2;
            set
            {
                name2 = value;
            }
        }

        public string Color1
        {
            get => color1;
            set
            {
                color1 = value;
            }
        }

        public string Color2
        {
            get => color2;
            set
            {
                color2 = value;
            }
        }

        public bool HasIA
        {
            get => hasIA;
            set
            {
                hasIA = value;
            }
        }

        public IAStrategy Strat
        {
            get => strat;
            set
            {
                strat = value;
            }
        }

        public void createGame()
        {
            Game.INSTANCE.Players[0]= createPlayer(Name1, Color1);
            if (HasIA)
            {
                Game.INSTANCE.Players[1] = createIAPlayer();
                Game.INSTANCE.gameHasIA = true;
            }
            else
            {
                Game.INSTANCE.Players[1] = createPlayer(Name2, Color2);
            }

            int[] coord = ComputePiecesCoordinates();



        }

        public HumanPlayer createPlayer(string n, string c)
        {
            return new HumanPlayer(n, c);
        }

        public IAPlayer createIAPlayer()
        {
            return new IAPlayer(Name2, Color2, Strat);
        }

        public abstract void PlacePieces(int[] coord);

        public abstract int[] ComputePiecesCoordinates();
    }
}