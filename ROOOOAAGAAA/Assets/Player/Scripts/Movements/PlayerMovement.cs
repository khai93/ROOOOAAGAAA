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

    private bool _isFacingRight = true;
    private float _direction = 0;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float dir = 0;

        if (Input.GetKey(leftKey))
        {
            if (_isFacingRight)
            {
                Flip();
            }

            dir -= 1;
        } 

        if (Input.GetKey(rightKey))
        {
            if (!_isFacingRight)
            {
                Flip();
            }

            dir += 1;
        } 

        if (!Input.GetKey(rightKey) && !Input.GetKey(leftKey))
        {
            dir = 0;
        }

        _direction = dir;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _sr.flipX = !_isFacingRight;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(WalkSpeed * _direction * 10 * Time.deltaTime, _rb.velocity.y);
    }
}
