using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    public class DestroyAfterLifetime : MonoBehaviour
    {
        [SerializeField]
        private float Lifetime;

        [SerializeField]
        private GameObject effectPrefab;

        private float _timeToDie;

        private void Awake()
        {
            _timeToDie = Time.time + Lifetime;
        }

        private void Update()
        {
            var DeathTimePassed = Time.time >= _timeToDie;

            if (DeathTimePassed)
            {
                TryShowEffect();
                Destroy(gameObject);
            }
        }

        private void TryShowEffect()
        {
            if (effectPrefab != null)
            {
                GameObject effect = Instantiate(effectPrefab);
                effect.transform.position = transform.position;
            }
        }
    }
}
