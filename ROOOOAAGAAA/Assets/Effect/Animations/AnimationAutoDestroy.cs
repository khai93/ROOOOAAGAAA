using UnityEngine;

namespace ROOOOAAGAAA.Effect
{
    [RequireComponent(typeof(Animator))]
    public class AnimationAutoDestroy : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}