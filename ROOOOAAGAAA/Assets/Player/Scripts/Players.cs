using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Better to rename this class to 
// PlayersContainer
public class Players : MonoBehaviour
{
    public static Players Instance;

    // Yes, it is a list. But a list of what?
    // Better to rename it to Players
    public List<Transform> list;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            foreach (Transform player in transform)
            {
                list.Add(player);
            }
        }
    }

    public static bool isAlive() => Instance.list.Any(p => p.gameobject.activeSelf);
}
