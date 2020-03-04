﻿using ROOOOAAGAAA.Persistence;

namespace ROOOOAAGAAA.Core
{
    public static class GameManager
    {
        // Consider using linked list.
        public static int Boss { get; private set; }

        public static void ResetGame()
        {
            Boss = 0;
        }

        public static void SaveGame()
        {
            SaveSystem.Save();
        }

        // Prefer to use XML docs for comments.
        // Prefer not to return success flags, instead just throw an exception if it failed.

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
                Boss = data.Boss;
                return;
            }

            throw new System.Exception("Could not load game.");
        }

    }
}