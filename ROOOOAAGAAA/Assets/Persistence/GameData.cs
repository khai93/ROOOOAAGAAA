using ROOOOAAGAAA.Core;

namespace ROOOOAAGAAA.Persistence
{
    [System.Serializable]
    public class GameData
    {
        public int BossIndex;

        public GameData()
        {
            BossIndex = GameManager.BossIndex;
        }
    }
}