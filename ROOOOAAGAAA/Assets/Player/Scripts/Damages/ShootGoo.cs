using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShootGoo : MonoBehaviour
{
    [SerializeField]
    private Transform FirePoint;

    [SerializeField]
    private KeyCode ShootKey;

    [SerializeField]
    private float Damage;

    [SerializeField]
    private float cooldown;

    private float _cd;

    private SpriteRenderer _spr;

    private void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();   
    }

    private void Update()
    {
        var canShootGood = Input.GetKeyDown(ShootKey) && Time.time >= _cd;
        if (canShootGood)
        {
            ShootGoo();
        }
    }

    private void ShootGoo()
    {
        var GooInstance = GooPool.Instance.Get();
        GooInstance.Init(transform, "Enemy", Damage);

        // If Player is flipped then flip firepoint position
        Vector3 flippedFirepoint = FirePoint.position - new Vector3(0.59f * 2, 0);
        GooInstance.transform.position = (_spr.flipX ? flippedFirepoint : FirePoint.position);

        GooInstance.gameObject.SetActive(true);
        _cd = Time.time + cooldown;
    }
}
