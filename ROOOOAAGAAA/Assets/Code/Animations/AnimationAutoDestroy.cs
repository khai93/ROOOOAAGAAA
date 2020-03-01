using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationAutoDestroy : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, GetComponent<Animation>().clip.length);
    }
}
