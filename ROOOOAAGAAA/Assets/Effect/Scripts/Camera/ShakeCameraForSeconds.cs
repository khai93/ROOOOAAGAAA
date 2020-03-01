using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraForSeconds : MonoBehaviour
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private float strength;

    private void Awake()
    {
        Camera main = Camera.main;
        CameraShake shake = main.GetComponent<CameraShake>();

        if (shake != null)
        {
            shake.Shake(strength, duration);
        }
    }
}
