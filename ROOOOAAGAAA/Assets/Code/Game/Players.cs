using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

    public static Players instance;

    public static List<Transform> list;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            foreach (Transform ply in transform)
            {
                list.Add(ply);
            }
        }
    }
}
