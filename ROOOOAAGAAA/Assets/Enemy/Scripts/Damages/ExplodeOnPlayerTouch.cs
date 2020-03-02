using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnPlayerTouch : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShowEffect();
            DealDamage();
            Destroy(gameObject);
        }
    }

    private void ShowEffect()
    {
        var effect = Instantiate(explosionPrefab);
        effect.transform.position = transform.position;
    }

    private void DealDamage()
    {
        ITakeDamage _takeDamage = collision.GetComponent<ITakeDamage>();
        // I don't think there was any point casting.
        _takeDamage.TakeDamage(Damage);
    }
}
