using ROOOOAAGAAA.Core;
using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    public class DamageOnPlayerTouch : MonoBehaviour
    {
        [SerializeField]
        private GameObject effectPrefab;

        [SerializeField]
        private float Damage;

        [SerializeField]
        private bool DestroyOnTouch;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                TryShowEffect();
                DealDamage(collision);

                if (DestroyOnTouch)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void TryShowEffect()
        {
            if (effectPrefab != null)
            {
                var effect = Instantiate(effectPrefab);
                effect.transform.position = transform.position;
            }
            
        }

        private void DealDamage(Collider2D collision)
        {
            IDamageable _takeDamage = collision.GetComponent<IDamageable>();
            _takeDamage.TakeDamage(Damage);
        }
    }
}
