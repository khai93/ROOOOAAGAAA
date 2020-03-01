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

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(leftKey))
        {
            if (isFacingRight)
            {
                Flip();
            }

            direction = -1;
        } 

        if (Input.GetKeyDown(rightKey))
        {
            if (!isFacingRight)
            {
                Flip();
            }

            direction = 1;
        } 

        if (!Input.GetKey(rightKey) && !Input.GetKey(leftKey))
        {
            direction = 0;
        }
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
