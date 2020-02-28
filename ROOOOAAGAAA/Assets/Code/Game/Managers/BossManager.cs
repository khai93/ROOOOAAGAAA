using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public static Transform currentBossObject;
   
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }
}
