using UnityEngine;
using ROOOOAAGAAA.Core;

namespace ROOOOAAGAAA.Combat
{
    public class FlyTowardsTarget : MonoBehaviour, ITarget<Transform>
    {
        [SerializeField]
        private float Speed;

        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            if (_target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, Speed * Time.deltaTime);
            }
        }
    }
}
