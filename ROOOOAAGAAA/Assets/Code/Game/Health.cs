using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ITakeDamage
{
    public float MaxHealth;

    [SerializeField]
    private float HealthRegenRate;

    [SerializeField]
    private GameObject DeathEffectPrefab;

    private float HealthRegenCD;
    private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
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
        _health = MaxHealth * (percentage/100);
    }

    private void Die()
    {
        gameObject.SetActive(false);

        if (DeathEffectPrefab != null)
        {
            var effect = Instantiate(DeathEffectPrefab);
            effect.transform.position = transform.position;
        }
    }
}
