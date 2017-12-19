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

        public Player(string n, string col, int nJoueur, int nBTiles)
        {
            Color = col;
            Name = n;
            pieces = PieceFactory.INSTANCE.CreateNPieces(nBTiles, nJoueur);
        }

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
            piece1.carryBall = false;
            piece2.carryBall = true;
        }

        public void movePiece(Diaballik.Piece Piece, int x, int y)
        {
            Piece.coordX = x;
            Piece.coordY = y;
        }
    }
}