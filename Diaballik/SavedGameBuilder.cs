using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class SavedGameBuilder : BuilderGame
    {
        private SaveGameData savedfile;

        public SavedGameBuilder(string name1, string name2, string colour1, string colour2, int nbTiles): base(name1, name2, colour1, colour2, nbTiles)
        {
        }

        public SavedGameBuilder(string name1, string name2, string colour1, string colour2, int nbTiles, IAStrategy st) : base(name1, name2, colour1, colour2, nbTiles, st)
        {
        }

        ~SavedGameBuilder()
        {
            throw new System.NotImplementedException();
        }

        public Diaballik.SaveGameData savedFile
        {
            get => savedfile;
            set
            {
                savedfile = value;
            }
        }

        public override int[] ComputePiecesCoordinates()
        {
            throw new System.NotImplementedException();
        }

        public override int[] ComputeBallCoordinates()
        {
            throw new System.NotImplementedException();
        }
    }
}