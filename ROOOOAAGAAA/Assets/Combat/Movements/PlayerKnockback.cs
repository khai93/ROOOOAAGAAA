using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerKnockback : MonoBehaviour, IKnockbackable
    {
        [SerializeField]
        private float Strength;

        private Rigidbody2D _rb;
        private SpriteRenderer _spr;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spr = GetComponent<SpriteRenderer>();
        }

        public void Knockback()
        {
            float scalar = (_spr.flipX ? 1 : -1);

            _rb.AddForce(transform.right * scalar * (Strength*25), ForceMode2D.Force);
        }
    }
}
