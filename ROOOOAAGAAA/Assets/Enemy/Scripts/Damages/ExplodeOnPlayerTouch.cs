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
            var effect = Instantiate(explosionPrefab);
            effect.transform.position = transform.position;

            ITakeDamage _takeDamage = collision.GetComponent<ITakeDamage>();

            if (_takeDamage is ITakeDamage)
            {
                _takeDamage.TakeDamage(Damage);
            }

            Destroy(gameObject);
        }
    }
}
