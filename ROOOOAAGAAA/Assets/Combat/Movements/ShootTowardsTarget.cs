using ROOOOAAGAAA.Core;
using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    public class ShootTowardsTarget : MonoBehaviour, ITarget<Transform>
    {
        [SerializeField]
        private float Speed;

        private Transform _target;
        private bool _shot;

        public void SetTarget(Transform target)
        {
            if (_shot)
                return;

            _target = target;
            transform.right = _target.position - transform.position;
            _shot = true;
        }

        private void Update()
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }
    }
}
