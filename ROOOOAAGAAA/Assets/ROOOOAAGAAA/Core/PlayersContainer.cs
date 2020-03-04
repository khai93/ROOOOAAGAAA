using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ROOOOAAGAAA.Core
{
    public class PlayersContainer : MonoBehaviour
    {
        public static PlayersContainer Instance;

        public List<Transform> Players;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                foreach (Transform player in transform)
                {
                    Players.Add(player);
                }
            }
        }

        public static bool IsAlive() => Instance.Players.Any(p => p.gameObject.activeSelf);
    }

}