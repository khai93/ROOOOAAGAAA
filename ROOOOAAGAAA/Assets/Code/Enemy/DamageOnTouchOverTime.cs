using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouchOverTime : MonoBehaviour
{
    [SerializeField]
    private string TargetTag;

    [SerializeField]
    private float Damage;

    [SerializeField]
    private float DelayInSeconds;

    private float nextCD;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetTag) && Time.time > nextCD)
        {
            Health health = collision.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(Damage);
            }

            nextCD = Time.time + DelayInSeconds;
        }
    }
}
