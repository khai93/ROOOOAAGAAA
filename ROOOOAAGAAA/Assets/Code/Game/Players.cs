using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public static Players Instance;

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

    public static bool isAlive()
    {
        bool alive = false;

        foreach (Transform player in Instance.list)
        {
            if (player.gameObject.activeSelf)
            {
                alive = true;
            }
        }

        return alive;
    }
}
