using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float WalkSpeed;
    [SerializeField]
    private KeyCode leftKey;
    [SerializeField]
    private KeyCode rightKey;

    private bool isFacingRight = true;
    private float direction = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sr;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float dir = 0;

        if (Input.GetKey(leftKey))
        {
            if (isFacingRight)
            {
                Flip();
            }

            dir -= 1;
        } 

        if (Input.GetKey(rightKey))
        {
            if (!isFacingRight)
            {
                Flip();
            }

            dir += 1;
        } 

        if (!Input.GetKey(rightKey) && !Input.GetKey(leftKey))
        {
            dir = 0;
        }

        Debug.Log(dir);

        direction = dir;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        sr.flipX = !isFacingRight;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(WalkSpeed * direction * 10 * Time.deltaTime, rb.velocity.y);
    }
}
