using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Engine
{
    [Serializable]
    public enum TileTypes
    {
        Default = 0,
        PiecePlayer0 = 1,
        BallPlayer0 = 2,
        PiecePlayer1 = 3,
        BallPlayer1 = 4,
    };

    [Serializable]
    public class Board
    {
        public TileTypes[,] Tiles { get; set; }
        public int BoardSize { get; set; }
        public int MovePieceCount { get; private set; }

        public Board()
        {  
        }

        public Board(int nbTiles)
        {
            if (nbTiles%2 == 1)
            {
                BoardSize = nbTiles;
                Tiles = new TileTypes[BoardSize, BoardSize];
            }
            else
            {
                throw new ArgumentException("La taille du Board doit être impaire");
            }  
        }

        // Seulement utilisé pour les tests
        public Board(TileTypes[,] tiles)
        {
            if (tiles.Length%2 == 1)
            {
                BoardSize = tiles.Length;
                Tiles = tiles;
            }
            else
            {
                throw new ArgumentException("La taille du Board doit être impaire");
            }
            
        }

        public void MovePiece(int PrevX, int PrevY, int NextX, int NextY)
        {
            if (PrevX == -1 && PrevY == -1) // Initialisation du Board
            {
                Tiles[NextX, NextY] = (NextX == 0) ? TileTypes.PiecePlayer0 : TileTypes.PiecePlayer1;
            }
            else
            {
                Tiles[NextX, NextY] = Tiles[PrevX, PrevY];
                Tiles[PrevX, PrevY] = TileTypes.Default;
            }
        }

        public void MoveBall(int PrevX, int PrevY, int NextX, int NextY)
        {
            if (PrevX == -1 && PrevY == -1)
            {
                Tiles[NextX, NextY] = (NextX == 0) ? TileTypes.BallPlayer0 : TileTypes.BallPlayer1;
            }
            else
            {
                Tiles[NextX, NextY] = Tiles[PrevX, PrevY];
                if (Tiles[NextX, NextY] == TileTypes.BallPlayer0) Tiles[PrevX, PrevY] = TileTypes.PiecePlayer0;
                if (Tiles[NextX, NextY] == TileTypes.BallPlayer1) Tiles[PrevX, PrevY] = TileTypes.PiecePlayer1;

            }
        }

        public override String ToString()
        {
            String res;
            res = "\tEtat du board: \n";
            for (int i = 0 ; i < BoardSize; i++)
            {
                res += "\t\t";
                for (int j = 0; j < BoardSize; j++)
                {
                    res += (int) Tiles[j, i] + " ";
                }
               res += "\n";
            }
            return res;
        }
    }
}