namespace Diaballik.Engine.Builder
{
    public class LoadGameBuilder : GameBuilder
    {
        public string FileName { get; set; }

        public LoadGameBuilder()
        {

        }

        ~LoadGameBuilder()
        {

        }

        public static GameBuilder Create()
        {
            GameBuilder builderGame = new LoadGameBuilder();
            return builderGame;
        }



        public LoadGameBuilder SetFileName(string fileName)
            {
                FileName = fileName;
                return this;
            }

            public override Game Build()
            {
                return GameSaveManager.Load(FileName); // TO FIX MAYBE
            }

    }
}
