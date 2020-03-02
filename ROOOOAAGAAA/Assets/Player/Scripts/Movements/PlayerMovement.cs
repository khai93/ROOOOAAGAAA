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

    // this is very confusing for someone who is not familiar with the code.
    // Does it mean that the opposite is left? Or straight or back?
    // To make the intention more clear, you can use enum. (refer to bottom).
    // private Direction Facing = Facing.Right;
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

        // all of this cannot happen simulatiously
        // either one will happen
        if (Input.GetKey(leftKey) && _isFacingRight)
        {
            Flip();
            dir -= 1;
        }
        else if (Input.GetKey(rightKey) && !_isFacingRight)
        {
            Flip();
            // It's confusing: what does it mean to direction to be incremented?
            // Is it the speed at which it moves?
            dir += 1;
        }
        // the last condition was redundant, because default value is 0 anyways.
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

// Facing example
enum Direction
{
    Left,
    Right,
    Forward,
    Back
}

