using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Engine
{
    [Serializable]
    public enum Tiles
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