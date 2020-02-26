using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static readonly string dataPath = Application.persistentDataPath + "/game.data";

    public static void Save ()
    {
        BinaryFormatter formatter =  new BinaryFormatter();
        
        using (FileStream stream = new FileStream(dataPath, FileMode.Create))
        {
            GameData gameData = new GameData();

            formatter.Serialize(stream, gameData);
        }
    }

    public static GameData LoadGame()
    {
        if (File.Exists(dataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            using (FileStream stream = new FileStream(dataPath, FileMode.Open))
            {
                GameData data = formatter.Deserialize(stream) as GameData;
                return data;
            }
        } else
        {
            Debug.LogError("Save File Doesn't Exist At " + dataPath);
            return null;
        }
    }

    public static bool DataFileExists() => File.Exists(dataPath);
}
