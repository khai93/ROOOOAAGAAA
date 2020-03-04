using ROOOOAAGAAA.Persistence;
using System.Collections.Generic;
using UnityEngine;

namespace ROOOOAAGAAA.Core
{
    public static class GameManager
    {
        public static int BossIndex { get; private set; }

        public static void ResetGame()
        {
            BossIndex = 0;
        }

        public static void SaveGame()
        {
            SaveSystem.Save();
        }

        /// <summary>
        /// Loads game with the current active boss.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">Thrown when game was not loaded successfully</exception>
        public static void LoadGame()
        {
            GameData data = SaveSystem.LoadGame();

            if (data != null)
            {
                BossIndex = data.BossIndex;
                return;
            }

            throw new System.Exception("Could not load game.");
        }

    }
}