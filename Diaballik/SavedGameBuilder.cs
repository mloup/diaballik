using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class SavedGameBuilder : BuilderGame
    {
        private SaveGameData savedfile;

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
    }
}