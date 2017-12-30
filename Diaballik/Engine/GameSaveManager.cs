using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Diaballik.Engine
{
    /// <summary>
    /// Class used to manage the writing and the reading of the save files.
    /// </summary>
    public static class GameSaveManager
    {
        /// <summary>
        /// Loads a saved instance of Game from the given path to its file.
        /// </summary>
        public static Game Load(string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            Game g = (Game)formatter.Deserialize(stream);
            stream.Close();
            return g;
        }

        /// <summary>
        /// Save an instance of Game to the given path of the new file.
        /// </summary>
        public static void Save(Game game, string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, game);
            stream.Close();
        }
    }
}