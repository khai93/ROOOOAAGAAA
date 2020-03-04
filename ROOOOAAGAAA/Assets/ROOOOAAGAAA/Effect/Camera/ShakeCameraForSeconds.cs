using UnityEngine;

namespace ROOOOAAGAAA.Effect
{
    public class ShakeCameraForSeconds : MonoBehaviour
    {
        [SerializeField]
        private float Duration;

        [SerializeField]
        private float Strength;

        private void Awake()
        {
            Camera main = Camera.main;
            CameraShake shake = main.GetComponent<CameraShake>();
            shake?.Shake(Strength, Duration);
        }
    }
}
