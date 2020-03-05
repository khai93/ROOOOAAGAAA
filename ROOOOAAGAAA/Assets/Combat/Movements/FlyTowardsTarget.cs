using UnityEngine;
using ROOOOAAGAAA.Core;

namespace ROOOOAAGAAA.Combat
{
    public class FlyTowardsTarget : MonoBehaviour, ITarget<Transform>
    {
        [SerializeField]
        private float speed;

        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            if (_target is Transform)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
            }
        }
    }
}
