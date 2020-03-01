
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

    private float cd;

    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(ShootKey) && Time.time >= cd)
        {
            var GooInstance = GooPool.Instance.Get();

            // Init Goo with enemy tag "Enemy" for players
            GooInstance.Init(transform, "Enemy", Damage);

            // If Player is flipped then flip firepoint position

            Vector3 flippedFirepoint = FirePoint.position - new Vector3(0.59f * 2, 0);
            GooInstance.transform.position = (spr.flipX ? flippedFirepoint : FirePoint.position);

            GooInstance.gameObject.SetActive(true);
            cd = Time.time + cooldown;
        }
    }
}
