using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private Transform GroundCheck;

    [SerializeField]
    private LayerMask groundLayer;

    // I think it would be better to have control checks in one centralized place.
    // Let controls manager be responsible for all the controls.
    // PlayerJump is just a behaviour. It shouldn't trigger itself.
    // ControlsManager should trigger PlayerJump. It sounds natural that way.
    [SerializeField]
    private KeyCode jumpKey;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float maxJumps;

    private Rigidbody2D _rb;

    // Should be IsGrounded.
    public bool _isGrounded;
    private float _JumpsLeft;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _JumpsLeft = maxJumps;
    }

    private void Update()
    {
        TryToJump();
        UpdateJump();
    }

    private void TryToJump()
    {
        var canJump = Input.GetKeyDown(jumpKey) && _JumpsLeft > 0;
        if (canJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _JumpsLeft--;
        }
    }

    private void UpdateJump()
    {
        if (_isGrounded && _JumpsLeft <= 0)
        {
            _JumpsLeft = maxJumps;
        }

        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, groundLayer);
    }


}
