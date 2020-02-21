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

            foreach (Transform ply in transform)
            {
                list.Add(ply);
            }
        }
    }
}
