using UnityEngine;

[RequireComponent(typeof(ShootGoo))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(PlayerMovement))]
public class ControlsManager : MonoBehaviour
{
    // Keys
    [SerializeField]
    private KeyCode LeftKey;
    [SerializeField]
    private KeyCode RightKey;
    [SerializeField]
    private KeyCode JumpKey;
    [SerializeField]
    private KeyCode ShootKey;

    // Serialized Private Config Variables
    [SerializeField]
    private float _JumpForce;
    [SerializeField]
    private int _MaxJumps;
    [SerializeField]
    private float _WalkSpeed;
    [SerializeField]
    private float _Damage;
    [SerializeField]
    private float _ShootCooldown;

    // Public Configuration Variables
    public float JumpForce { get { return _JumpForce; } private set { _JumpForce = value; } }
    public int MaxJumps { get { return _MaxJumps; } private set { _MaxJumps = value; } }
    public float WalkSpeed { get { return _WalkSpeed; } private set { _WalkSpeed = value; } }
    public float Damage { get { return _Damage; } private set { _Damage = value; } }
    public float ShootCooldown { get { return _ShootCooldown; } private set { _ShootCooldown = value; } }

    // Components
    [SerializeField]
    private Transform GroundCheck;
    [SerializeField]
    private LayerMask GroundLayer;

    // Other
    public bool IsGrounded;

    // Required Behavior Components
    private ShootGoo _shootGoo;
    private PlayerJump _playerJump;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _shootGoo = GetComponent<ShootGoo>();
        _playerJump = GetComponent<PlayerJump>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckMovementInputs();
        CheckJumpInputs();
        CheckShootGooInputs();

        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, GroundLayer);
    }

    private void CheckJumpInputs()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            _playerJump.TryToJump();
        }
    }

    private void CheckMovementInputs()
    {
        if (Input.GetKeyDown(LeftKey))
        {
            _playerMovement.Move(Direction.Left);
        }

        if (Input.GetKeyDown(RightKey))
        {
            _playerMovement.Move(Direction.Right);
        }

        // Reset Scalar if player is not moving
        if (!Input.GetKey(LeftKey) && !Input.GetKey(RightKey))
        {
            _playerMovement.ResetScalar();
        }
    }

    private void CheckShootGooInputs()
    {
        if (Input.GetKeyDown(ShootKey))
        {
            _shootGoo.TryToShoot();
        }
    }
}
