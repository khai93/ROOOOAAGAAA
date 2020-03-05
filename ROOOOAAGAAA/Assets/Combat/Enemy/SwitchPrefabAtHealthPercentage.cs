using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(Health))]
    public class SwitchPrefabAtHealthPercentage : MonoBehaviour
    {
        [SerializeField]
        private GameObject TransitionEffect;

        [SerializeField]
        private GameObject NextPrefab;

        [SerializeField]
        private float ActivateAtHealthPercentage;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            var isHealthUnderMax = _health.GetCurrentHealth() <= _health.MaxHealth * (ActivateAtHealthPercentage / 100);
            if (isHealthUnderMax)
            {
                SwitchPrefab();
                Destroy(gameObject);
            }
        }

        private void SwitchPrefab()
        {
            GameObject newEntity = Instantiate(NextPrefab);
            newEntity.transform.position = transform.position;

            if (TransitionEffect != null)
            {
                GameObject effect = Instantiate(TransitionEffect);
                effect.transform.position = transform.position;
            }
        }
    }
}
