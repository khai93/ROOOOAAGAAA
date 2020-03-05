using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Renderer))]
    public class FlashRedOnHit : MonoBehaviour
    {
        private Health _health;
        private Renderer _renderer;
        private float _baseRed;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _renderer = GetComponent<Renderer>();

            _health.Damaged += OnDamaged;
        }

        private void Start()
        {
            _baseRed = _renderer.material.color.r;
        }

        private void Update()
        {
            if (_renderer.material.color.r > _baseRed)
            {
                _renderer.material.color = new Color(_renderer.material.color.r - 4f * Time.deltaTime, _renderer.material.color.g, _renderer.material.color.b, _renderer.material.color.a);
            }
            else
            {
                _renderer.material.color = new Color(_baseRed, _renderer.material.color.g, _renderer.material.color.b, _renderer.material.color.a);
            }
        }


        private void OnDamaged()
        {
            _renderer.material.color = new Color(_baseRed + 2f, _renderer.material.color.g, _renderer.material.color.b);
        }

        private void OnDestroy()
        {
            _health.Damaged -= OnDamaged;
        }
    }
}
