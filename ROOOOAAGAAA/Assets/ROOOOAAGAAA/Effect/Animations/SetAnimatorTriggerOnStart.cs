using UnityEngine;

namespace ROOOOAAGAAA.Effect
{
    [RequireComponent(typeof(Animator))]
    public class SetAnimatorTriggerOnStart : MonoBehaviour
    {
        [SerializeField]
        private string Trigger;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animator.SetTrigger(Trigger);
        }
    }
}