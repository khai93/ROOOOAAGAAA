using ROOOOAAGAAA.Core;
using System;
using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    public class Health : MonoBehaviour, IDamageable
    {
        public float MaxHealth;

        public event Action Damaged;

        [SerializeField]
        private float HealthRegenRate;

        [SerializeField]
        private GameObject DeathEffectPrefab;

        [SerializeField]
        private bool DestroyOnDeath;

        private float HealthRegenCD;
        private float _health;

        private SpriteRenderer _renderer;

        public void TakeDamage(float damage)
        {
            _health -= damage;

            Damaged?.Invoke();
        }

        private void Awake()
        {
            _health = MaxHealth;
        }

        private void Update()
        {
            // Death Check
            if (_health <= 0)
            {
                Die();
            }


            // Health Regen
            if (Time.time >= HealthRegenCD && _health < MaxHealth)
            {
                _health += 1;
                HealthRegenCD = Time.time + HealthRegenRate;
            }

            // Safety Check
            if (_health > MaxHealth)
            {
                _health = MaxHealth;
            }
        }

        public float GetCurrentHealth()
        {
            return _health;
        }

        public void SetHealthPercentage(float percentage)
        {
            _health = MaxHealth * (percentage / 100);
        }

        private void Die()
        {
            if (DeathEffectPrefab != null)
            {
                var effect = Instantiate(DeathEffectPrefab);
                effect.transform.position = transform.position;
            }

            if (DestroyOnDeath)
            {
                Destroy(gameObject);
            }

            gameObject.SetActive(false);
        }
    }
}
