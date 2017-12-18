using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class Piece
    {
        private Boolean carryball;
        private int cX;
        private int cY;
        private int joueur;

        public Piece(int joueur)
        {
            carryBall = false;
            cX = -1;
            cY = -1;
        }

        ~Piece()
        {
        }

        public Boolean carryBall
        {
            get => carryball;
            set
            {
                carryball = value;
            }
        }

        public int coordX
        {
            get => cX;
            set
            {
                cX = value;
            }
        }

        public int coordY
        {
            get => cY;
            set
            {
                cY = value;
            }
        }

        public int Joueur
        {
            get => joueur;
            set
            {
                joueur = value;
            }
        }

        public Boolean Equals(Piece piece)
        {
            if (this.Joueur == piece.Joueur && this.coordX == piece.coordX && this.coordY == piece.coordY && this.carryBall == piece.carryBall) return true;
            return false;
        }
    }
}