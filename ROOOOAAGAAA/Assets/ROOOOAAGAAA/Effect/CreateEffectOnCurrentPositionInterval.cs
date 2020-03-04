using UnityEngine;

namespace ROOOOAAGAAA.Effect
{
    public class CreateEffectOnCurrentPositionInterval : MonoBehaviour
    {
        [SerializeField]
        private GameObject EffectPrefab;

        [SerializeField]
        private float SpawnRateInSeconds;

        private float nextTime;

        private void Awake()
        {
            nextTime = SpawnRateInSeconds;
        }

        private void Update()
        {
            if (Time.time >= nextTime)
            {
                var Effect = Instantiate(EffectPrefab);
                Effect.transform.position = transform.position;
                nextTime = Time.time + SpawnRateInSeconds;
            }
        }
    }
}
