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
        private int nbtiles;

        public BuilderGame(string n1, string n2, string c1, string c2, int nbTiles)
        {
            Name1 = n1;
            Name2 = n2;
            Color1 = c1;
            Color2 = c2;
            NbTiles = nbTiles;
            Strat = null;
            hasIA = false;
        }

        public BuilderGame(string n1, string n2, string c1, string c2, int nbTiles, IAStrategy st)
        {
            Name1 = n1;
            Name2 = n2;
            Color1 = c1;
            Color2 = c2;
            NbTiles = nbTiles;
            Strat = st;
            hasIA = true;
        }

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

        public int NbTiles
        {
            get => nbtiles;
            set
            {
                nbtiles = value;
            }
        }

        public void CreateGame()
        {
            Game.INSTANCE.Players[0]= CreatePlayer(Name1, Color1, 0);
            if (HasIA)
            {
                Game.INSTANCE.Players[1] = CreateIAPlayer();
                Game.INSTANCE.gameHasIA = true;
            }
            else
            {
                Game.INSTANCE.Players[1] = CreatePlayer(Name2, Color2, 1);
            }

            int[] coord = ComputePiecesCoordinates();
            PlacePieces(coord);
            
            //Run le Game ici

        }

        public HumanPlayer CreatePlayer(string n, string c, int nJoueur)
        {
            return new HumanPlayer(n, c, nJoueur, NbTiles);
        }

        public IAPlayer CreateIAPlayer()
        {
            return new IAPlayer(Name2, Color2, NbTiles, Strat);
        }

        public void PlacePieces(int[] coord)
        {
            for(int i = 0; i < NbTiles*2; i+=2)
            {
                MovePiece move = new MovePiece(-1, -1, coord[i], coord[i + 1]);
                move.Do();
                Actions.INSTANCE.push(move);
            }
            for (int i = NbTiles * 2; i < NbTiles * 4; i += 2)
            {
                MovePiece move = new MovePiece(-1, -1, coord[i], coord[i + 1]);
                move.Do();
                Actions.INSTANCE.push(move);
            }
        }

        public void PlaceBalls(int[] coord)
        {
            Game.INSTANCE.Players[0].Pieces[coord[0]].carryBall = true;
            Game.INSTANCE.Players[1].Pieces[coord[1]].carryBall = true;
        }

        public abstract int[] ComputePiecesCoordinates();
        public abstract int[] ComputeBallCoordinates();
    }
}