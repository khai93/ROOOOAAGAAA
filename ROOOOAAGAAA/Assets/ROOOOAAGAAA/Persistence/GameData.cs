using ROOOOAAGAAA.Core;

namespace ROOOOAAGAAA.Persistence
{
    [System.Serializable]
    public class GameData
    {
        public int Boss;

        public GameData()
        {
            Boss = GameManager.Boss;
        }
    }
}