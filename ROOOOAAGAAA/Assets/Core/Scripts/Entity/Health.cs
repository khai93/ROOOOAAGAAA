using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float MaxHealth;

    [SerializeField]
    private float HealthRegenRate;

    [SerializeField]
    private GameObject DeathEffectPrefab;

    [SerializeField]
    private bool flashRedWhenHit;

    [SerializeField]
    private bool DestroyOnDeath;

    private float HealthRegenCD;
    private float _health;
    private float baseRed;
    private Renderer _renderer;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (flashRedWhenHit)
        {
            _renderer.material.color = new Color(baseRed+1f, _renderer.material.color.g, _renderer.material.color.b);
        }
    }

    private void Awake()
    {
        _health = MaxHealth;
        _renderer = GetComponent<Renderer>();
        baseRed = _renderer.material.color.r;
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

        // Flash red
        if (_renderer.material.color.r > baseRed)
        {
            _renderer.material.color = new Color(_renderer.material.color.r - 2f * Time.deltaTime, _renderer.material.color.g, _renderer.material.color.b, _renderer.material.color.a);
        } else
        {
            _renderer.material.color = new Color(baseRed , _renderer.material.color.g, _renderer.material.color.b, _renderer.material.color.a);
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
