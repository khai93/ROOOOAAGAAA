using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorAnimationAutoDestroy : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}