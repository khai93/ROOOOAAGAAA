using UnityEngine;

[RequireComponent(typeof(Animation))]
public class SwitchPrefabAfterAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject TransitionEffect;

    [SerializeField]
    private GameObject NextPrefab;

    private float _animationEndTime;
    private Animation _anim;
    private void Start()
    {
        _anim = GetComponent<Animation>();
        _animationEndTime = Time.time + _anim.clip.length;
    }

    private void Update()
    {
        if (Time.time <= _animationEndTime) return;

        GameObject newEntity = Instantiate(NextPrefab);
        newEntity.transform.position = transform.position;

        if (TransitionEffect != null)
        {
            GameObject effect = Instantiate(TransitionEffect);
            effect.transform.position = transform.position;
        }

        Destroy(gameObject);
    }
}
