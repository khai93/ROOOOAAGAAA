using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private Transform GroundCheck;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private KeyCode jumpKey;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float maxJumps;

    private Rigidbody2D _rb;

    public bool _isGrounded;
    private float _JumpsLeft;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _JumpsLeft = maxJumps;
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            if (_JumpsLeft >0)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                _JumpsLeft--;
            }
        }

        if (_isGrounded && _JumpsLeft <= 0)
        {
            _JumpsLeft = maxJumps;
        }

        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, groundLayer);
    }
}
