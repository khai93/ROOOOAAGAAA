using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private float MaxHealth;

    [SerializeField]
    private float HealthRegenRate;

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
        if (_health <= 0)
        {
            Die();
        }

        if (Time.time >= HealthRegenCD)
        {
            _health += 1;
            HealthRegenCD = Time.time + HealthRegenRate;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
