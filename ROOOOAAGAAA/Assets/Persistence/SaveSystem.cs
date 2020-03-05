using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ROOOOAAGAAA.Persistence
{
    public static class SaveSystem
    {
        private static readonly string _dataPath = $"{Application.persistentDataPath}/game.data";

        public static void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(_dataPath, FileMode.Create))
            {
                GameData gameData = new GameData();

                formatter.Serialize(stream, gameData);
            }
        }

        public static GameData LoadGame()
        {
            if (File.Exists(_dataPath))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream stream = new FileStream(_dataPath, FileMode.Open))
                {
                    GameData data = formatter.Deserialize(stream) as GameData;
                    return data;
                }
            }
            else
            {
                throw new FileNotFoundException("Data file doesn't exist.");
            }
        }
    }
}
