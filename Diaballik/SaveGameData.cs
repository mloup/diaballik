using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class SaveGameData
    {
        private Actions actions;
        private string c1;
        private string c2;
        private int currplayer;
        private bool hasia;
        private bool isfinished;
        private string name1;
        private string name2;
        private int nbactions;

        public SaveGameData(Actions actions, string name1, string name2, string color1, string color2, bool hasIA, IAStrategy strategy, int nbActions, int currentPlayer)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Pour une partie finie
        /// </summary>
        public SaveGameData(Actions actions, string name1, string name2, string color1, string color2)
        {
            throw new System.NotImplementedException();
        }

        ~SaveGameData()
        {
            throw new System.NotImplementedException();
        }

        public Actions Actions
        {
            get => actions;
            set
            {
                actions = value;
            }
        }

        public String namePlayer1
        {
            get => name1;
            set
            {
                name1 = value;
            }
        }

        public String namePlayer2
        {
            get => name2;
            set
            {
                name2 = value;
            }
        }

        public string colourPlayer1
        {
            get => c1;
            set
            {
                c1 = value;
            }
        }

        public string colourPlayer2
        {
            get => c2;
            set
            {
                c2 = value;
            }
        }

        public Boolean isFinished
        {
            get => isfinished;
            set
            {
                isfinished = value;
            }
        }

        public bool hasIA
        {
            get => hasia;
            set
            {
                hasia = value;
            }
        }

        public int nbActions
        {
            get => nbactions;
            set
            {
                nbactions = value;
            }
        }

        public int currentPlayer
        {
            get => currplayer;
            set
            {
                currplayer = value;
            }
        }

        public void SaveFile()
        {
            throw new System.NotImplementedException();
        }
    }
}