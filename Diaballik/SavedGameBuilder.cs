using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class SavedGameBuilder : BuilderGame
    {
        private SaveGameData savedfile;

        public SavedGameBuilder(string name1, string name2, string colour1, string colour2, int nbTiles)
        {
        }

        public SavedGameBuilder(string name1, string name2, string colour1, string colour2, int nbTiles, IAStrategy st)
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

        protected override Board FillBoard()
        {
            throw new NotImplementedException();
        }
    }
}