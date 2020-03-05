using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(KeyboardKeyBinder))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float WalkSpeed;

        private Direction _Facing = Direction.Right;
        private float _scalar = 0;

        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private KeyboardKeyBinder _keyBinder;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _keyBinder = GetComponent<KeyboardKeyBinder>();
        }

        private void Flip()
        {
            bool facingRight = _Facing == Direction.Right;
            _Facing = facingRight ? Direction.Left : Direction.Right;
            _sr.flipX = facingRight;
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(WalkSpeed * _scalar * 10 * Time.deltaTime, _rb.velocity.y);
        }

        public void Move(Direction dirPressed)
        {
            float scalar = 0;

            if (dirPressed == Direction.Left)
            {
                // Flip if changed direction while moving
                if (_Facing == Direction.Right)
                    Flip();

                scalar -= 1;
            }
            else if (dirPressed == Direction.Right)
            {
                if (_Facing == Direction.Left)
                    Flip();

                scalar += 1;
            }

            _scalar = scalar;
        }

        public void ResetScalar()
        {
            _scalar = 0;
        }
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}

