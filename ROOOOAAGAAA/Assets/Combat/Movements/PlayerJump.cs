using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(KeyboardKeyBinder))]
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField]
        private float JumpForce;
        [SerializeField]
        private int MaxJumps;


        [SerializeField]
        private Transform GroundCheck;
        [SerializeField]
        private LayerMask GroundLayer;

        public bool IsGrounded;

        private Rigidbody2D _rb;
        private KeyboardKeyBinder _keyBinder;

        private float _JumpsLeft;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _keyBinder = GetComponent<KeyboardKeyBinder>();
            _JumpsLeft = MaxJumps;
        }

        private void Update()
        {
            IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, GroundLayer);

            if (IsGrounded && _JumpsLeft <= 0)
            {
                _JumpsLeft = MaxJumps;
            }
        }

        public void TryToJump()
        {
            var canJump = IsGrounded || _JumpsLeft > 0;

            if (canJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
                _JumpsLeft--;
            }
        }
    }
}