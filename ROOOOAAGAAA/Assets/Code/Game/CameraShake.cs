using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originialPosition;
    private float shakeAmount = 0;

    private void Awake()
    {
        originialPosition = transform.position;
    }

    public void Shake(float _shakeAmount, float duration)
    {
        shakeAmount = _shakeAmount;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", duration);
    }

    private void cameraShake()
    {
        if (shakeAmount > 0)
        {
            float quakeAmt = Random.value * shakeAmount * 2 - shakeAmount;
            Vector3 pp = transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            transform.position = pp;
        }
    }

    private void StopShaking()
    {
        CancelInvoke("CameraShake");
        transform.position = originialPosition;
    }
}
