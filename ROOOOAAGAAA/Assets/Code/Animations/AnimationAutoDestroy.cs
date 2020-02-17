using UnityEngine;
using System.Collections;

public class AnimationAutoDestroy : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}