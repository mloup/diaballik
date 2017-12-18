using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class PieceFactory
    {
        public static Diaballik.PieceFactory INSTANCE = new PieceFactory();

        private PieceFactory(){}

        ~PieceFactory()
        {

        }

        public Piece[] CreateNPieces(int nbPieces, int joueur)
        {
            Piece[] rep = new Piece[nbPieces];
            for(int i = 0; i < nbPieces; i++)
            {
                rep[i] = new Piece(joueur);
            }
            return rep;
        }
    }
}