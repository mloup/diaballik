using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class Player
    {
        private string color;
        private string name;
        private Piece[] pieces;

        public string Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        public String Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public Diaballik.Piece[] Pieces
        {
            get => pieces;
            set
            {
                pieces = value;
            }
        }

        /// <param name="piece1">Piece où était la balle</param>
        /// <param name="piece2">Pièce où va la balle</param>
        public void moveBall(Diaballik.Piece piece1, Diaballik.Piece piece2)
        {
            throw new System.NotImplementedException();
        }

        public void movePiece(Diaballik.Piece Piece, int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}