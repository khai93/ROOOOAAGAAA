using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwitchPrefabAfterAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject TransitionEffect;

    [SerializeField]
    private GameObject NextPrefab;

    private float _animationEndTime;
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _animationEndTime = Time.time + _anim.GetCurrentAnimatorStateInfo(0).length;
    }

    private void Update()
    {
        if (Time.time < _animationEndTime) return;

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
