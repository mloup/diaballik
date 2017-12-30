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
        public Tiles[,] Tiles { get; set; }
        public int BoardSize { get; set; }

        public Board()
        {  
        }

        public Board(int nbTiles)
        {
            if (nbTiles%2 == 1)
            {
                BoardSize = nbTiles;
                Tiles = new Tiles[BoardSize, BoardSize];
            }
            else
            {
                throw new ArgumentException("La taille du Board doit être impaire");
            }  
        }

        // Seulement utilisé pour les tests
        public Board(Tiles[,] tiles)
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

        ~Board()
        {
            throw new System.NotImplementedException();
        }

        public void GetPossibleMoves(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}