using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(KeyboardKeyBinder))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class ShootGoo : MonoBehaviour
    {
        [SerializeField]
        private Transform FirePoint;

        [SerializeField]
        private float Damage;

        [SerializeField]
        private float ShootCooldown;

        private SpriteRenderer _spr;
        private KeyboardKeyBinder _keyBinder;
        private float _cd;

        private void Awake()
        {
            _spr = GetComponent<SpriteRenderer>();
            _keyBinder = GetComponent<KeyboardKeyBinder>();
        }

        public void TryToShoot()
        {
            var canShootGoo = Time.time >= _cd;

            if (canShootGoo)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            var GooInstance = GooPool.Instance.Get();
            GooInstance.Init(transform, "Enemy", Damage);

            // If Player is flipped then flip firepoint position
            Vector3 flippedFirepoint = FirePoint.position - new Vector3(0.59f * 2, 0);
            GooInstance.transform.position = (_spr.flipX ? flippedFirepoint : FirePoint.position);

            GooInstance.gameObject.SetActive(true);
            _cd = Time.time + ShootCooldown;
        }
    }
}