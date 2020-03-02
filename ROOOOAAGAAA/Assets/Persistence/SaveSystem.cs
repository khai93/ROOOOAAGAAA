using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static readonly string _dataPath = @$"{Application.persistentDataPath}/game.data";

    public static void Save ()
    {
        BinaryFormatter formatter =  new BinaryFormatter();
        
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
        } else
        {
            Debug.LogError("Save File Doesn't Exist At " + _dataPath);
            return null;
        }
    }

    // The context is GameData.
    // GameData.Exists() is enough, because the rest is known from the calling context.
    public static bool DataFileExists() => File.Exists(_dataPath);
}
