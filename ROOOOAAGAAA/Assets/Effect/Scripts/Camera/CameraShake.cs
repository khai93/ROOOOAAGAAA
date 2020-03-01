using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originialPosition;
    private float _shakeAmount = 0;

    private void Awake()
    {
        _originialPosition = transform.position;
    }

    public void Shake(float _shakeAmount, float duration)
    {
        this._shakeAmount = _shakeAmount;
        InvokeRepeating("cameraShake", 0, .01f);
        Invoke("StopShaking", duration);
    }

    private void cameraShake()
    {
        if (_shakeAmount > 0)
        {
            Vector3 pp = transform.position + Random.insideUnitSphere * _shakeAmount;
            transform.position = pp;
        }
    }

    private void StopShaking()
    {
        CancelInvoke("cameraShake");
        transform.position = _originialPosition;
    }
}
