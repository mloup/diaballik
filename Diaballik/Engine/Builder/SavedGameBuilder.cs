using System;

namespace Diaballik.Engine.Builder
{
    public class SavedGameBuilder : GameBuilder
    {
        public string FileName { get; set; }

        public SavedGameBuilder()
        {

        }

        ~SavedGameBuilder()
        {

        }

        public static GameBuilder Create()
        {
            GameBuilder builderGame = new SavedGameBuilder();
            return builderGame;
        }



        public SavedGameBuilder SetFileName(string fileName)
            {
                FileName = fileName;
                return this;
            }

            public override Game Build()
            {
                MyGameToBuild = GameSaveManager.Load(FileName);
                return MyGameToBuild;
            }

        protected override void FillBoard()
        {
        }
    }
}
