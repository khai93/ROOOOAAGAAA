
public static class GameManager
{
    public static int Boss { get; private set; }

    public static void ResetGame()
    {
        Boss = 1;
    }

    public static void SaveGame()
    {
        SaveSystem.Save();
    }

    // returns true if successfully loaded else false
    public static bool LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        if (data != null)
        {
            Boss = data.Boss;
            return true;
        }

        return false;
    }

}
