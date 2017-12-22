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
            Game.INSTANCE.Players[0]= CreatePlayer(Name1, Color1); //pourquoi ne pas mettre directement le new HumanPlayer ici ?
            if (HasIA)
            {
                Game.INSTANCE.Players[1] = CreateIAPlayer(); //pourquoi ne pas mettre directement le new IAPlayer ici ?
                Game.INSTANCE.GameHasIA = true;
            }
            else
            {
                Game.INSTANCE.Players[1] = CreatePlayer(Name2, Color2);
            }

            int[] coord = ComputePiecesCoordinates();
            PlacePieces(coord);
            
            //Run le Game ici

        }

        public HumanPlayer CreatePlayer(string n, string c)
        {
            return new HumanPlayer(n, c);
        }

        public IAPlayer CreateIAPlayer()
        {
            return new IAPlayer(Name2, Color2, strat);
        }

        public void CreateBoard()
        {
            Game.INSTANCE.Board = new Board(NbTiles);
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
            Game.INSTANCE.Board.Tiles[coord[0],0 ] = Tiles.BallPlayer0;
            Game.INSTANCE.Board.Tiles[coord[1], Game.INSTANCE.Board.BoardSize - 1] = Tiles.BallPlayer1;
        }

        public abstract int[] ComputePiecesCoordinates();
        public abstract int[] ComputeBallCoordinates();
    }
}