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

    private float _nextCD;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag(TargetTag) && Time.time >= _nextCD)
        {
            Debug.Log(collision.tag);
            Health health = collision.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(Damage);
            }

            _nextCD = Time.time + DelayInSeconds;
        }
    }
}
