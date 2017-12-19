using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class BallRandomBuilder : BuilderGame
    {
        public BallRandomBuilder(string name1, string name2, string colour1, string colour2, int nbTiles): base(name1, name2, colour1, colour2, nbTiles)
        {
        }

        public BallRandomBuilder(string name1, string name2, string colour1, string colour2, int nbTiles, IAStrategy st) : base(name1, name2, colour1, colour2, nbTiles, st)
        {
        }

        ~BallRandomBuilder()
        {
            throw new System.NotImplementedException();
        }

        public override int[] ComputePiecesCoordinates()
        {
            int[] coord = new int[NbTiles * 4];

            // Pieces du premier joueur
            for (int i = 0; i < NbTiles * 2; i += 2)
            {
                coord[i + 1] = 0;
                coord[i] = i / 2;
            }
            // Pieces du second joueur
            for (int i = NbTiles * 2; i < NbTiles * 4; i += 2)
            {
                coord[i + 1] = NbTiles - 1;
                coord[i] = (i - NbTiles * 2) / 2;
            }
            return coord;
        }

        public override int[] ComputeBallCoordinates()
        {
            Random random = new Random();
            int[] res = { random.Next(0, NbTiles), random.Next(0, NbTiles) };
            return res;
        }
    }
}