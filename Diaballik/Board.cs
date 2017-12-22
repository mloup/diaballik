using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public enum Tiles
    {
        Default = 0,
        PiecePlayer0 = 1,
        BallPlayer0 = 2,
        PiecePlayer1 = 3,
        BallPlayer1 = 4,
    };

    public class Board
    {
        private Tiles[,] tiles;
        private int boardSize;

        public Board()
        {  
        }

        public Board(int nbTiles)
        {
            int boardSize = nbTiles;
            tiles = new Tiles[boardSize, boardSize];
        }

        ~Board()
        {
            throw new System.NotImplementedException();
        }

        public Tiles[,] Tiles
        {
            get => tiles;
            set
            {
                tiles = value;
            }
        }

        public int BoardSize
        {
            get => default(int);
            set
            {
            }
        }

        public void GetPossibleMoves(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}