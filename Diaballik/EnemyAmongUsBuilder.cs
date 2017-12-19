using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class EnemyAmongUsBuilder : BuilderGame
    {

        public EnemyAmongUsBuilder(string name1, string name2, string colour1, string colour2, int nbTiles): base(name1, name2, colour1, colour2, nbTiles)
        {
        }

        public EnemyAmongUsBuilder(string name1, string name2, string colour1, string colour2, int nbTiles, IAStrategy st) : base(name1, name2, colour1, colour2, nbTiles, st)
        {
        }

        ~EnemyAmongUsBuilder()
        {
            throw new System.NotImplementedException();
        }

        public override int[] ComputePiecesCoordinates()
        {
            int[] coord = new int[NbTiles * 4];

            Random random = new Random();
            int nEAU = random.Next(1, 4);
            int cpt = 0;
            int[] pos = new int[nEAU];

            int rand = random.Next(0, 2);

            for (int i = 0; i < NbTiles * 2; i += 2)
            {
                rand = random.Next(0, 2);
                if (rand == 1 && cpt < nEAU && (i/2 != NbTiles/2 +1))
                {
                    coord[i + 1] = NbTiles - 1;
                    pos[cpt] = i / 2;
                    cpt++;
                }
                else
                {
                    coord[i + 1] = 0;
                }

                coord[i] = i / 2;
            }
            cpt = 0;
            for (int i = NbTiles * 2; i < NbTiles * 4; i += 2)
            {
                if (cpt < nEAU && ((i - NbTiles * 2) / 2) == pos[cpt])
                {
                    coord[i + 1] = 0;
                    cpt++;
                }
                else
                {
                    coord[i + 1] = NbTiles - 1;
                }
                coord[i] = (i - NbTiles * 2) / 2;
            }

            return coord;
        }
        public override int[] ComputeBallCoordinates()
        {
            int[] res = { NbTiles / 2 + 1, NbTiles / 2 + 1 };
            return res;
        }
    }
}