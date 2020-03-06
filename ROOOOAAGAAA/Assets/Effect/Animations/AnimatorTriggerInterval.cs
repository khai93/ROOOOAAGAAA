using UnityEngine;

namespace ROOOOAAGAAA.Effect
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorTriggerInterval : MonoBehaviour
    {
        [SerializeField]
        private string Trigger;

        [SerializeField]
        private float TriggerRate;

        [SerializeField]
        private float DelayToStart;

        private Animator _animator;
        private float _TriggerCD;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _TriggerCD = Time.time + DelayToStart;
        }

        private void Update()
        {
            if (Time.time <= _TriggerCD) return;

            _animator.SetTrigger(Trigger);
            _TriggerCD = Time.time + TriggerRate; 
        }
    }
}
