using UnityEngine;

namespace ROOOOAAGAAA.Combat
{
    [RequireComponent(typeof(ShootGoo))]
    [RequireComponent(typeof(PlayerJump))]
    [RequireComponent(typeof(PlayerMovement))]
    public class KeyboardKeyBinder : MonoBehaviour
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
}