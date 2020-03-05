using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(IKnockbackable))]
    [RequireComponent(typeof(Health))]
    public class KnockbackOnHit : MonoBehaviour
    {

        private Health _health;
        private IKnockbackable _knockback;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _knockback = GetComponent<IKnockbackable>();

            _health.Damaged += OnDamaged;
        }

        private void OnDamaged()
        {
            _knockback.Knockback();
        }

        private void OnDestroy()
        {
            _health.Damaged -= OnDamaged;
        }
    }
}
