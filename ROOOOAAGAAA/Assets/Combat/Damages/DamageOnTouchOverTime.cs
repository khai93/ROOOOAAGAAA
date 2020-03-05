using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
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
            bool isTargetHitAndNoCooldown = collision.CompareTag(TargetTag) && Time.time >= _nextCD;
            if (isTargetHitAndNoCooldown)
            {
                Debug.Log(collision.tag);
                DealDamage(collision);
                _nextCD = Time.time + DelayInSeconds;
            }
        }

        private void DealDamage(Collider2D collision)
        {
            Health health = collision.GetComponent<Health>();
            health?.TakeDamage(Damage);
        }
    }
}